using System;
using spaar.ModLoader;
using spaar.ModLoader.UI;
using UnityEngine;

namespace spaar.Mods.EnhancedCamera
{
  public class EnhancedMouseOrbit : MouseOrbit
  {
    public Vector3 UpDownTranslation = new Vector3(0, 1, 0);

    private Key forward, backward, left, right, up, down, menu;

    private float fov;

    private bool guiVisible = false;
    private int windowID = Util.GetWindowID();
    private Rect windowRect = new Rect(150, 150, 200, 360);

    public void CopyFrom(MouseOrbit o)
    {
      target = o.target;
      distance = o.distance;
      xSpeed = o.xSpeed;
      ySpeed = o.ySpeed;
      yMinLimit = o.yMinLimit;
      yMaxLimit = o.yMaxLimit;
      x = o.x;
      y = o.y;
      smooth = o.smooth;
      wasdPosOffset = o.wasdPosOffset;
      wasdSpeed = o.wasdSpeed;
      zoomSmooth = o.zoomSmooth;
      introDuration = o.introDuration;
      introXamount = o.introXamount;
      introYamount = o.introYamount;
      filmCamSmooth = o.filmCamSmooth;
      panSpeed = o.panSpeed;
      machineTarget = o.machineTarget;
      focusObject = o.focusObject;
      focusLerpSmooth = o.focusLerpSmooth;
      dofTarget = o.dofTarget;
      minZoom = o.minZoom;
      maxZoom = o.maxZoom;
      mouseSensitivityScaler = o.mouseSensitivityScaler;
      scrollSensitivityScaler = o.scrollSensitivityScaler;
      fixedCam = o.fixedCam;
      fixedCamObj = o.fixedCamObj;
      fixedCamLookAt = o.fixedCamLookAt;
      fixedCamLerpPosSpeed = o.fixedCamLerpPosSpeed;
      fixedCamLerpRotSpeed = o.fixedCamLerpRotSpeed;
      lerpedUpVector = o.lerpedUpVector;
      yPosClamp = o.yPosClamp;
      hud3Dcam = o.hud3Dcam;

      forward = Keybindings.Get("Forward");
      backward = Keybindings.Get("Backward");
      left = Keybindings.Get("Left");
      right = Keybindings.Get("Right");
      up = Keybindings.Get("Up");
      down = Keybindings.Get("Down");
      menu = Keybindings.Get("Menu");

      wasdSpeed = Configuration.GetFloat("wasdSpeed", wasdSpeed);
      scrollSensitivityScaler = Configuration.GetFloat("scrollSpeed",
        scrollSensitivityScaler);
      fov = Configuration.GetFloat("fov", Camera.main.fieldOfView);
      focusLerpSmooth = Configuration.GetFloat("focusLerpSmooth", focusLerpSmooth);
    }

    public override void WASD()
    {
      if (Input.GetKey(KeyCode.W))
      {
        // Counteract vanilla W movement
        wasdPosOffset = wasdPosOffset - (Vector3.Cross(transform.right, Vector3.up) * wasdSpeed);
      }
      if (Input.GetKey(KeyCode.S))
      {
        // Counteract vanilla S movement
        wasdPosOffset = wasdPosOffset + (Vector3.Cross(transform.right, Vector3.up) * wasdSpeed);
      }
      if (Input.GetKey(KeyCode.A))
      {
        // Counteract vanilla A movement
        wasdPosOffset = wasdPosOffset + (transform.right * wasdSpeed);
      }
      if (Input.GetKey(KeyCode.D))
      {
        // Counteract vanilla D movement
        wasdPosOffset = wasdPosOffset - (transform.right * wasdSpeed);
      }

      if (forward.IsDown())
      {
        wasdPosOffset = wasdPosOffset + (transform.forward * wasdSpeed);
      }

      if (backward.IsDown())
      {
        wasdPosOffset = wasdPosOffset - (transform.forward * wasdSpeed);
      }
      if (left.IsDown()) {
        wasdPosOffset = wasdPosOffset - (transform.right * wasdSpeed);
      }
      if (right.IsDown())
      {
        wasdPosOffset = wasdPosOffset + (transform.right * wasdSpeed);
      }

      if (up.IsDown())
      {
        wasdPosOffset = wasdPosOffset + (transform.up * wasdSpeed);
      }
      if (down.IsDown())
      {
        wasdPosOffset = wasdPosOffset - (transform.up * wasdSpeed);
      }

      if (menu.Pressed())
      {
        guiVisible = !guiVisible;
      }

      base.WASD();
    }

    private void OnGUI()
    {
      if (!guiVisible) return;

      GUI.skin = ModGUI.Skin;
      windowRect = GUI.Window(windowID, windowRect, DoWindow, "Enhanced Camera");
    }

    private void DoWindow(int id)
    {
      GUILayout.Label("Keyboard speed:");

      var oldSpeed = wasdSpeed;
      wasdSpeed = GUILayout.HorizontalSlider(wasdSpeed, 0.0f, 5.0f);
      float.TryParse(GUILayout.TextField(wasdSpeed.ToString()), out wasdSpeed);

      if (oldSpeed != wasdSpeed)
      {
        Configuration.SetFloat("wasdSpeed", wasdSpeed);
      }

      GUILayout.Label("Zoom speed:");

      oldSpeed = scrollSensitivityScaler;
      scrollSensitivityScaler = GUILayout.HorizontalSlider(
        scrollSensitivityScaler, 0.0f, 5.0f);
      float.TryParse(GUILayout.TextField(scrollSensitivityScaler.ToString()),
        out scrollSensitivityScaler);

      if (oldSpeed != scrollSensitivityScaler)
      {
        Configuration.SetFloat("scrollSpeed", scrollSensitivityScaler);
      }

      GUILayout.Label("Field of view:");

      var oldFov = fov;
      fov = GUILayout.HorizontalSlider(fov, 40f, 100f);
      float.TryParse(GUILayout.TextField(fov.ToString()), out fov);

      if (oldFov != fov)
      {
        Configuration.SetFloat("fov", fov);
        Camera.main.fieldOfView = fov;
      }

      GUILayout.Label("Focus smoothing:");

      var oldSmoothing = focusLerpSmooth;
      focusLerpSmooth = GUILayout.HorizontalSlider(focusLerpSmooth, 0f, 20f);

      float.TryParse(GUILayout.TextField(focusLerpSmooth.ToString()), out focusLerpSmooth);

      if (oldSmoothing != focusLerpSmooth)
      {
        Configuration.SetFloat("focusLerpSmooth", focusLerpSmooth);
      }

      GUI.DragWindow();
    }
  }
}
