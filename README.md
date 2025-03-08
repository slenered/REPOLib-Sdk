# REPOLib Sdk

**Unity editor tools for creating content for R.E.P.O. (using REPOLib).**

## Features

- Registering custom valuables without code
- Automatic asset bundling and Thunderstore packaging

## Usage

This section assumes you already have a Unity project set up for R.E.P.O. modding.
If not, use a tool like [R.E.P.O. Project Patcher](https://github.com/Kesomannen/unity-repo-project-patcher) first.

### Setup

**1. Add REPOLib to the project**

- Download REPOLib from Thunderstore ([link](https://thunderstore.io/c/repo/p/Zehs/REPOLib/)).
- Extract the downloaded file.
- Copy `REPOLib.dll` into your project.

**2. Add REPOLib-Sdk to the project**

- In unity, go to `Window > Package Manager`.
- Click the `+` button in the top left and choose `Add package from git URL`.
- Enter `https://github.com/ZehsTeam/REPOLib-Sdk.git`.

### Create a mod

- Create a new folder in your project.
- Right click in the folder, then choose `Create > REPOLib > Mod`.
- Fill in the fields on the `Mod` asset:
  - `Name`: the mod's name, as shown on Thunderstore. This can only contain numbers, letters and underscores.
  - `Author`: the name of your Thunderstore team.
  - `Version`: must be in the format `X.Y.Z`.
  - `Dependencies`: REPOLib should always be included.
  - `Icon`: must be a 256x256 PNG file.
  - `Readme`: a longer description of the mod, in a separate file. Supports markdown formatting.

> [!TIP]
> You can have multiple mods in the same project, as long as they're in separate folders.

### Create a valuable

- Create a valuable prefab.
  - More documentation is on its way here. For now, use the vanilla valuables as reference. If you used the patcher, they are located in `Assets/REPO/Game/Resources/valuables`.
- Right click in your mod folder (or any subfolder) and choose `Create > REPOLib > Valuable`.
- Fill in the fields:
  - `Prefab`: A reference to your prefab. The prefab does not have to be in the mod folder.
  - `Add to All Levels`: Whether to register the valuable on all levels or specify them yourself.
  - `Level Names`: The level presets to register the valuable in. Ignored if `Add to All Levels` is `true`. The vanilla values are:
    - `Valuables - Generic`
    - `Valuables - Wizard`
    - `Valuables - Manor`
    - `Valuables - Arctic`

### Export a mod

- Select the `Mod` asset and click `Export` in the inspector.
  - In the window you'll see the associated content files found by REPOLib-Sdk.
- Choose an `Output Path`. If there isn't a folder at the selected path, one will be created.
- Click `Export` and wait. Once finished, a window should appear showing the exported zip file. This file can be uploaded to Thunderstore or locally imported into mod managers.

> [!TIP]
> The export window can also be accessed from `Window > REPOLib Exporter`

## Contribute

Anyone is free to contribute.

https://github.com/ZehsTeam/REPOLib-Sdk

## Developer Contact

#### Report bugs, suggest features, or provide feedback:

- **GitHub Issues Page:** [REPOLib](https://github.com/ZehsTeam/REPOLib/issues)
- **Email:** crithaxxog@gmail.com
- **Twitch:** [CritHaxXoG](https://www.twitch.tv/crithaxxog)
- **YouTube:** [Zehs](https://www.youtube.com/channel/UCb4VEkc-_im0h8DKXlwmIAA)

[![kofi](https://i.imgur.com/jzwECeF.png)](https://ko-fi.com/zehsteam)
