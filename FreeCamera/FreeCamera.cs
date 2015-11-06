using System;
using spaar.ModLoader;
using UnityEngine;

namespace spaar.Mods.FreeCamera
{
  public class FreeCamera : SingleInstance<FreeCamera>
  {
    public override string Name { get; } = "Free Camera";

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
        var freeOrbit = Camera.main.gameObject.AddComponent<FreeMouseOrbit>();
        freeOrbit.CopyFrom(mouseOrbit);
        Destroy(mouseOrbit);

        FindObjectOfType<ResetCameraButton>().camCode = freeOrbit;
      }
    }
  }
}
