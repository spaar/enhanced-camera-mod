using System;
using spaar.ModLoader;
using UnityEngine;

namespace spaar.Mods.FreeCamera
{
  public class FreeMouseOrbit : MouseOrbit
  {
    public Vector3 UpDownTranslation = new Vector3(0, 1, 0);

    private Key forward, backward, left, right, up, down;

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
      wasdPOSdelegate = o.wasdPOSdelegate;
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

      forward = Keybindings.Get("Forward");
      backward = Keybindings.Get("Backward");
      left = Keybindings.Get("Left");
      right = Keybindings.Get("Right");
      up = Keybindings.Get("Up");
      down = Keybindings.Get("Down");
    }

    public override void WASD()
    {
      if (Input.GetKey(KeyCode.W))
      {
        // Counteract vanilla W movement
        wasdPOSdelegate = wasdPOSdelegate - (Vector3.Cross(transform.right, Vector3.up) * wasdSpeed);
      }
      if (Input.GetKey(KeyCode.S))
      {
        // Counteract vanilla S movement
        wasdPOSdelegate = wasdPOSdelegate + (Vector3.Cross(transform.right, Vector3.up) * wasdSpeed);
      }
      if (Input.GetKey(KeyCode.A))
      {
        // Counteract vanilla A movement
        wasdPOSdelegate = wasdPOSdelegate + (transform.right * wasdSpeed);
      }
      if (Input.GetKey(KeyCode.D))
      {
        // Counteract vanilla D movement
        wasdPOSdelegate = wasdPOSdelegate - (transform.right * wasdSpeed);
      }

      if (forward.IsDown())
      {
        wasdPOSdelegate = wasdPOSdelegate + (transform.forward * wasdSpeed);
      }

      if (backward.IsDown())
      {
        wasdPOSdelegate = wasdPOSdelegate - (transform.forward * wasdSpeed);
      }
      if (left.IsDown()) {
        wasdPOSdelegate = wasdPOSdelegate - (transform.right * wasdSpeed);
      }
      if (right.IsDown())
      {
        wasdPOSdelegate = wasdPOSdelegate + (transform.right * wasdSpeed);
      }

      if (up.IsDown())
      {
        wasdPOSdelegate = wasdPOSdelegate + (transform.up * wasdSpeed);
      }
      if (down.IsDown())
      {
        wasdPOSdelegate = wasdPOSdelegate - (transform.up * wasdSpeed);
      }

      base.WASD();
    }
  }
}
