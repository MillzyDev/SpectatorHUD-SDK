# Spectator HUD SDK
A unity package for making custom HUDs for the Spectator HUD BONELAB mod.

1. [Installation](#installation)
2. [Creating a new HUD](#creating-a-new-hud)
   3. [Optional Considerations](#optional-considerations)
   4. [Adding Counters](#adding-counters)
      5. [Health Modifier](#health-modifier)
      6. [Active With Gun Held In Hand](#active-with-gun-held-in-hand)
   7. [Animator Integration](#animator-integration)
      8. [TMP Material Property Overrides](#tmp-material-property-overrides)
      9. [Random Variables](#random-variables)
   10. [Shader Integration](#shader-integration)
11. [Exporting your HUD](#exporting-your-hud)
12. [License](#license)

## Installation
1. Get a compatible Unity environment set up. If you have a project you use for making SDK mods, I recommend using that. If not, follow the [setup guide for a Marrow SDK project](https://github.com/StressLevelZero/MarrowSDK/wiki/ProjectSetup).
2. Open the package manager by clicking `Window > Package Manager`
3. Click the `+` icon in the top left corner and then `Add package from git URL...`. ![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/add-package.png?raw=true)
4. In the URL field, paste this link: `https://github.com/MillzyDev/SpectatorHUD-SDK.git`
5. Close the package manager and click `Window > SpectatorHUD > Configure Project`
6. Done! You're all set to start creating custom HUDs.

## Creating a new HUD
1. Click `Window > SpectatorHUD > Create HUD`
2. Fill in the fields for the name of the HUD and the author (that's you!). Leave the version as `1` for now. ![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/create-hud.png?raw=true)
3. Once that's done click `Create`.
4. You're asset window will now be focused on a newly created folder containing a `Hud` and a `Hud.Version` assets. ![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/hud-assets.png?raw=true) These are assets that the SpectatorHUD mod uses when loading your HUD. They track the info you put in when creating them, the version of the SDK you are using, and the main prefab that (eventually) contains your HUD.
5. In this folder create a new prefab by right clicking and pressing `Create > Prefab`. You can name the prefab whatever you want.
6. Click back onto the `Hud` asset, and in the inspector drag the prefab you just created into the `Hud Asset` field. ![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/set-hud-asset.png?raw=true)
7. Double click on the prefab object you made to open it in the scene editor. ![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/open-prefab.png?raw=true)
8. Right click on the only object in the hierarchy and the click `UI > Canvas`.
9. Remove the `Graphic Raycaster` by selecting the created canvas in the hierarchy, then in the inspector click the three vertical dots and then `Remove Component`. ![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/remove-graphicraycaster.png?raw=true)
10. Make sure the canvas `Render Mode` is set to `Screen Space - Overlay`

Creating the HUD from here is the same as creating any unity UI. You can use whatever components so long as they are not stripped from the base game.

### Optional Considerations
It's highly recommended that you adjust the `Canvas Scaler` component to best suit you're HUD's design. I'd recommend using either `Scale With Screen Size` or `Constant Physical Size`, however please consider carefully which one you use.

### Adding Counters
Counters are TextMeshPro text object that SpectatorHUD sets to reflect the information it tracks such as health and ammo.
To add counters to your HUD, you need to add a `Hud Controller` component to the canvas:
1. Select the canvas in the hierarchy
2. Press the `Add Component Button`
3. Search for `Hud Controller` and/or click it when it shows up. ![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/add-controller.png?raw=true)

You should have a new component in the inspector that looks like this. 

![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/hud-controller.png?raw=true)

All of the `TMP_Text` fields are counters that SpectatorHUD sets.

| Field Name | What it tracks |
|------------|--|
|`Left Hand Reserve Counter` | Ammo reserve for the gun currently held in the left hand. Empty if not holding one. |
|`Left Hand Ammo Counter` | Ammo in the gun currently held in the left hand. Magazine (+1 chambered). Empty if not holding one. |
|`Right Hand Reserve Counter` | Ammo reserve for the gun currently held in the right hand. Empty if not holding one. |
|`Right Hand Ammo Counter` | Ammo in the gun currently held in the left hand. Magazine (+1 chambered). Empty if not holding one. |
|`Left Hand Total Ammo Counter` | Combined Ammo and Reserve counter for gun currently held in the left hand. Empty if not holding one. |
|`Right Hand Total Ammo Counter` | Combined Ammo and Reserve counter for gun currently held in the right hand. Empty if not holding one. |
|`Total Light Ammo Counter` | Count of all light ammo currently held by the player. |
|`Total Medium Ammo Counter` | Count of all medium ammo currently held by the player. |
|`Total Heavy Ammo Counter` | Count of all heavy ammo currently held by the player. |
|`Health Counter` | Integer representation of the player's current health, after being scaled by the fields in the `Health Modifier`. |
|`Max Health Counter` | Integer representation of the player's maxiumum health, after being scaled by the fields in the `Health Modifier`. |
|`Percentage Health Counter` | Integer representation of `(Current Health / Max Health) * 100`, |

Simply drag a game object in the prefab hierarchy with a TextMeshPro componet (such as `TextMeshProUGUI`) to the desired field. These can be created by right clicking on the canvas (or whatever you're parenting it to) `UI > Text - TextMeshPro`.

#### Health Modifier
The health modifier applies a linear transformation on the values supplied to the `Health Counter` and the `Max Health Counter`.
```
Health Displayed = (Original Value * Multiplier) + Offset
```
The default multiplier is 10. The Strong avatar has a health value of ~12.23, so after applying this multiplier it displays on the counter as 122 rather than 12.

#### Active With Gun Held In Hand
Game objects added to the list of each of these fields are disabled unless a gun is held in their respective hands.

### Animator Integration
Anything in the HUD can be animated without any special changes using the Unity Animation system. Spectator HUD is able to feed values and triggers to Unity `Animator` components so that your animations can respond to the HUD.

To get started, add an `Animation Controller` component to the canvas. 

![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/anim-controller.png?raw=true)

This component contains 27 different lists. These lists hold references to animators of which to send values to, and the names of which parameters to set.
Each one should be self explanatory, but make sure the property type in the animator matches what Spectator HUD is expecting each to be.

![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/anim-propertyref.png?raw=true)
![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/anim-graph.png?raw=true)

I won't talk about what each of them does since there's so many of them, but generally:
All of the Ammo-related values should be `Integer`s, the "Changed" propeties are `Trigger`s and the Health values are `Float`s.
The health percentage is scaled `0-1` rather than `0-100`.

#### TMP Material Property Overrides
TMP shaders for font assets can't be touched normally by the animation system. To get around this, there is a series of `TMPMaterialPropertyOverride` scripts for `Int`, `Float`, `Vector`, and `Color` values. 
Script fields can be changed with the animation system, so any value the `Value` field is set to will be matched in the font asset's shader.

![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/prop-override.png?raw=true)

#### Random Variables
You can feed scaled pseudorandom values into animator properties. This is useful for random transitions in animation sequences.
It works similarly to the Animation Controller.

Add the `RandomAnimationParameter` component to the appropriate place in your hierarchy (such as an empty child game object), and set up the fields as desired.

![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/random-anim-param.png?raw=true)

Set the `Animator` field to the animator you will be feeding random variables to, as well as the `Parameter Name` to the exact same name as the animator parameter (which should be a float).
The other fields control the random number generation.

| Field Name  | What it does                                                    |
|-------------|-----------------------------------------------------------------|
| Range Min   | The lower bound for the random number(s) generated              |
| Range Max   | the upper bound for the random number(s) generated              |
| Does Cycle  | Enables "cycling" for the varaible.                             |
| Buffer Size | How many random numbers should be generated for use in cycling. |
| Interval    | The time in seconds between each cycle                          |

The component works in two moded: Non-Cycled and Cycled. 

Non-Cycled is where a single random number is generated when the HUD is loaded, and that is set to the animator parameter just once.

Cycled mode very quickly fills a buffer containing the number of random variables specified in `Buffer Size`. 
This is done to be more performant instead of generating the numbers on the fly. 
The next random number in the buffer is fed to the parameter every interval and goes back to the beginning when it reaches the end.

> [!Warning]
> Don't make `Buffer Size` too big. 128 should be a decent amount, increase at your own risk.

### Shader Integration
HUD counter values can be fed to shaders using the `Shader Controller` component.

## Exporting your HUD
To export your HUD select the Hud asset that was created at the beginning, press the `Export HUD` button and select a location to save it to.

![](https://github.com/MillzyDev/SpectatorHUD-SDK/blob/main/files~/set-hud-asset.png?raw=true)

# License
Spectator HUD SDK
Copyright (c) 2026 Millzy

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.