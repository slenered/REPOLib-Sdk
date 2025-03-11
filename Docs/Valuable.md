# Valuables

Valuables are the pieces of loot you find throughout the level and extract for money.

Internally, a valuable is represented by a prefab with a `ValuableObject` component attached.
To register the valuable with REPOLib, a separate `ValuableContent` asset is also required.

The easiest way to get started with a valuable is to copy one from the base game. 
If you used the [R.E.P.O Unity Project Patcher](), they are located in `Assets/REPO/Game/Resources/valuables`. 

## Prefab structure

### Hierarchy

A standard hierarchy for a valuable:

![img_3.png](img_3.png)

- The root GameObject (`MyValuable`) contains the main scripts.
  - `Object` is the parent of the physics and rendering components. Here is where you can apply transformations specific to your model.
    - One or more renderers (`Mesh`)
    - One or more colliders (`Valuable Collider *`)

### Scripts

The following should be present on every valuable:

![img.png](img.png)

#### Photon View

Enables network functionality. Don't touch this.

#### Photon Transform View

Syncs the object's position across the network.

#### Valuable Object

The main script which defines the valuable's visual and gameplay properties.

![img_1.png](img_1.png)

- `Durability Preset`
  - `Fragility`: how easily the object breaks. The more fragile, the less force required.
  - `Durability`: the amount of value loss that comes from smashing the object.
  - You can creat a new preset from `Create > Phys Object > Durability Preset`.
- `Value Preset`: the valuable's starting sell value, randomized between a max and min.
- `Phys Attribute Preset`: defines the mass of the object.
- `Audio Preset`: contains various sound effects that the object makes.
- `Audio Preset Pitch`: at which pitch the sound effects will play at. `1` means unchanged.