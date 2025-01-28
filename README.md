# HarmonizedRaceHeights-Patcher
Synthesis patcher for my mod Harmonized Race Heights which is also a requisite.

https://www.nexusmods.com/skyrimspecialedition/mods/139918

## How it works
The winning override of your mods will be patched with the heights values of the various races from `Harmonized Race Heights.esp`.

So to be sure to keep the plugin of my mod very high and consider using the patches for USMP and High Poly Head Vampire fix from the nexus page if needed.

## Typical usage
So you will have for example:

`Unofficial Skyrim Special Edition Patch.esm -> Unofficial Skyrim Modders Patch.esm -> Harmonized Race Heights.esp -> ... -> *Harmonized Race Heights patches* -> *Eventual race overhaul mod* *Eventual patches for the race overhaul mod* -> ... -> Synthesis.esp`

This would be the ideal plugin order for this synthesis patcher to be run that will result in everything getting forwared in the Synthesis.esp file correctly.

## Upsides and downsides

I am aware there are other solutions and will try them as well but I honestly made this patcher more for the sake of experimenting with synthesis than for the actual functionality. Even so it might be useful at least for me and for someone else.

### Upsides

* This patcher should be great to patch a race mod (or multiple) in a matter of seconds if the user is already familiar and/or using synthesis.

* There should be no need to update the patcher since it relies on the heights values pulled from the plugin file, so if i change something or create new variants of the it will automatically forward the updated values (by of course running it again after the main mod update/change).

### Downsides

* It has it's limitations which are probably easly resolvable since it's my first synthesis patcher.

* You still need the patches for certain mods for example USMP since it cannot be loaded after my mod which will result in USMP changes not being forwarded in the final Synthesis.esp.
