using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Plugins.Records;

namespace HarmonizedRaceHeightsPatcher
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
            => await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "Harmonized Race Heights - Synthesis Patch.esp")
                .Run(args);

        private static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            var sourcePluginName = "Harmonized Race Heights.esp";
            var sourcePlugin = state.LoadOrder[sourcePluginName]?.Mod;

            if (sourcePlugin == null) //Pretty sure this is not really needed since Synthesis stops you from running this if main mod plugin file is not present.
            {
                throw new FileNotFoundException($"The required plugin '{sourcePluginName}' was not found in the load order.");
            }

            var raceHeightMap = new Dictionary<string, GenderedItem<float>>();

            foreach (var race in sourcePlugin.Races)
            {
                if (race.EditorID == null || race.Height == null) continue;

                raceHeightMap[race.EditorID] = (GenderedItem<float>)race.Height;
            }

            foreach (IRaceGetter winningOverride in state.LoadOrder.PriorityOrder.OnlyEnabled().Race().WinningOverrides())
            {
                if (winningOverride.EditorID == null) continue;

                if (raceHeightMap.TryGetValue(winningOverride.EditorID, out var heights))
                {
                    var raceOverride = state.PatchMod.Races.GetOrAddAsOverride(winningOverride);

                    raceOverride.Height = new Mutagen.Bethesda.Plugins.Records.GenderedItem<float>(heights.Male, heights.Female);

                    Console.WriteLine($"Harmonized the height for the '{winningOverride.Name}' race. ({winningOverride.EditorID})");
                }
            }
            Console.WriteLine("Race heights harmonized successfully!");
        }
    }
}