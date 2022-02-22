# Extra Gore Plugin

This unofficial TaleSpire plugin adds blood to the attacked mini and applies a blood camera filter for a few seconds
when an attack is made. The mini blood and blood camera filter are removed after the configurable duration expires.

This plugin, like all others, is free but if you want to donate, use: http://LordAshes.ca/TalespireDonate/Donate.php

## Change Log

```
1.0.0: Initial release
```

## Install

Use R2ModMan or similar installer to install this plugin.

This plugin has a default configuration which should work if you are using the default configration of EAR and the
Body Aura plugin. However, if you do not see Blood Camera Filter applied then follow these steps:

1. Locate the Extra Assets Registration Plugin installation folder.
2. Under CustomData/cache find the AssetInfo.cache file and open it using a text editor (like Notepad)
3. Search for "labloodfilter" (without the quotes)
4. Look at the id associated with it. It should look something like: 3e736d60-d31a-1a34-177a-867319885255
5. Now open the R2ModMan configration for this plugin and set the "Camera Filter Name" to the id you found
6. Save and restart TS

In the R2ModMan configuration, there is also a setting for the duration of the effect which can be set as desired.

## Usage

Currently this works with only core TS attacks. Support for Ruleset 5E is comming soon.

1. Click to select the attacking mini
2. Right click on the victim (attack target)
3. From the radial menu select one of the core attacks under the Attack sub-menu
4. Jump back as the blood hits your screen and the mini
5. Wait roughly 3 seconds (configurable) for an automatic clean up  

## Limitations

This plugins uses the Body Aura plugin to generate the mini blood and EAR to apply the blood camera filter.
The Body Aura plugin is currently not compatible with all assets and thus the mini blood effect may not appear.
