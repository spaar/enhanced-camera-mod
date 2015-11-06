using System;
using spaar.ModLoader;
using UnityEngine;

namespace spaar.Mods.EnhancedCamera
{
  public class EnhancedCamera : SingleInstance<EnhancedCamera>
  {
    public override string Name { get; } = "Enhanced Camera";

    public void Start()
    {
      ReplaceMouseOrbit();
    }

    public void OnLevelWasLoaded()
    {
      ReplaceMouseOrbit();
    }

    private void ReplaceMouseOrbit()
    {
      var mouseOrbit = Camera.main.GetComponent<MouseOrbit>();
      if (mouseOrbit != null)
      {
        var enhancedOrbit = Camera.main.gameObject.AddComponent<EnhancedMouseOrbit>();
        enhancedOrbit.CopyFrom(mouseOrbit);
        Destroy(mouseOrbit);

        FindObjectOfType<ResetCameraButton>().camCode = enhancedOrbit;
      }
    }
  }
}
