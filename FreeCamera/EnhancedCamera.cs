using System;
using spaar.ModLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace spaar.Mods.EnhancedCamera
{
  public class EnhancedCamera : SingleInstance<EnhancedCamera>
  {
    public override string Name { get; } = "Enhanced Camera";

    public void Start()
    {
      ReplaceMouseOrbit();

      SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
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
