using System;
using spaar.ModLoader;
using UnityEngine;

namespace spaar.Mods.FreeCamera
{

  // If you need documentation about any of these values or the mod loader
  // in general, take a look at https://spaar.github.io/besiege-modloader.

  public class FreeCameraMod : spaar.ModLoader.Mod
  {
    public override string Name { get; } = "freeCamera";
    public override string DisplayName { get; } = "Free Camera";
    public override string Author { get; } = "spaar";
    public override Version Version { get; } = new Version(1, 0, 0);

    public override string VersionExtra { get; } = "";

    public override bool CanBeUnloaded { get; } = false;
    public override bool Preload { get; } = false;


    public override void OnLoad()
    {
      UnityEngine.Object.DontDestroyOnLoad(FreeCamera.Instance);

      Keybindings.AddKeybinding("Forward", new Key(KeyCode.None, KeyCode.W));
      Keybindings.AddKeybinding("Backward", new Key(KeyCode.None, KeyCode.S));
      Keybindings.AddKeybinding("Left", new Key(KeyCode.None, KeyCode.A));
      Keybindings.AddKeybinding("Right", new Key(KeyCode.None, KeyCode.D));
      Keybindings.AddKeybinding("Up", new Key(KeyCode.None, KeyCode.Q));
      Keybindings.AddKeybinding("Down", new Key(KeyCode.None, KeyCode.E));
    }

    public override void OnUnload()
    {

    }
  }
}
