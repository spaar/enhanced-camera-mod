using System;
using UnityEngine;

namespace spaar.Mods.FreeCamera
{
  public class FreeMouseOrbit : MouseOrbit
  {
    public Vector3 UpDownTranslation = new Vector3(0, 1, 0);

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
    }

    public override void WASD()
    {
      if (Input.GetKey(KeyCode.W))
      {
        // Counteract vanilla W movement
        wasdPOSdelegate = wasdPOSdelegate - (Vector3.Cross(transform.right, Vector3.up) * wasdSpeed);

        wasdPOSdelegate = wasdPOSdelegate + (transform.forward * wasdSpeed);
      }
      if (Input.GetKey(KeyCode.S))
      {
        // Counteract vanilla S movement
        wasdPOSdelegate = wasdPOSdelegate + (Vector3.Cross(transform.right, Vector3.up) * wasdSpeed);

        wasdPOSdelegate = wasdPOSdelegate - (transform.forward * wasdSpeed);
      }

      if (Input.GetKey(KeyCode.Q))
      {
        wasdPOSdelegate = wasdPOSdelegate + (transform.up * wasdSpeed);
      }
      if (Input.GetKey(KeyCode.E))
      {
        wasdPOSdelegate = wasdPOSdelegate - (transform.up * wasdSpeed);
      }

      base.WASD();
    }
  }
}
