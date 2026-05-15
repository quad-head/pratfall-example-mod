# Pratfall Example Mod

Official example mod for Pratfall.

This repository demonstrates:
- Mod folder structure
- `manifest.json`
- Godot `.pck` packaging
- C# mod entrypoints
- Scene loading

Current engine version: Godot 4.6.1 .NET

Join our Discord to ask questions, discuss modding, share your creations or get help from the community and developers.

[![Join our Discord](https://img.shields.io/badge/Discord-Join%20Server-5865F2?logo=discord&logoColor=white)](https://discord.gg/b9EvyJKd97)

---

# Mod Folder Structure

Mods must be placed in:

```text
GameFolder/mods/<modname>
```

Example:

```text
GameFolder/mods/example_mod
```

Your mod folder should look like this:

```text
example_mod/
├── manifest.json
├── Mod.pck
└── Mod.dll
```

---

# manifest.json

Every mod requires a `manifest.json`.

Example:

```json
{
  "Name": "Example Mod",
  "Version": "1.0.0",
  "Description": "My description",
  "Author": "My name",
  "PackageName": "ExampleMod.pck",
  "Assembly": "ExampleMod.dll",
  "AutoLoad": false
}
```

---

# Godot Assets (.pck)

Mods can include Godot assets and scenes using a `.pck` package.

The package must contain:
- a folder with the same name as the mod
- a `root.tscn` scene inside that folder

Example:

```text
example_mod/
└── root.tscn
```

The `root.tscn` scene will automatically be added by the game when the mod loads.

## Exporting a .pck

You can export `.pck` files directly from Godot.

See the official Godot documentation:

https://docs.godotengine.org/en/stable/tutorials/export/exporting_pcks.html

The exported package should be named:

```text
Mod.pck
```

and placed inside your mod folder.

---

# C# Modding

Mods can include C# code using a `.dll` assembly.

The game looks for a static class named:

```csharp
ModEntry
```

with the following functions:

```csharp
public static class ModEntry
{
    public static void ModInit()
    {
    }

    public static void ModDestroy()
    {
    }
}
```

The compiled assembly should be named:

```text
Mod.dll
```

and placed inside your mod folder.

After exporting the mod, the compiled `.dll` (e.g. `Mod.dll`) can be found in the project under `.godot/mono/temp/bin`.

## ModInit()

Called when the mod loads.

Use this to:
- initialize systems
- register content
- set up hooks/events

## ModDestroy()

Called when the mod unloads or the game closes.

Use this to:
- clean up resources
- unregister events
- stop background tasks

---

# Command Line Arguments

The game supports the following command line arguments for mod management:

```text
--qh-disable-mod-ui
```

Hides the mod UI button in the main menu.

```text
--qh-skip-mods
```

Skips loading all mods at game startup.

These can be useful for debugging, testing vanilla behavior or running the game in a clean state.

---

# Warning

Mod unloading may cause issues with C# code if references are still held in memory (for example static events, singletons, or Godot objects). In some cases, assemblies cannot be fully unloaded until the application restarts.
