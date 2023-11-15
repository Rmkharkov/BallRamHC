using System;
using UnityEngine;

namespace Misc
{
    public class CameraAutoFieldOfView : MonoBehaviour
    {
        private Camera Cam => Camera.main;
        private CameraConfig UsedCamConfig => CameraConfig.Instance;
        
        private void Start()
        {
            AutoSetCamera();
        }

        private void AutoSetCamera()
        {
            var curResolution = new Vector2(Screen.width, Screen.height);
            
            var screenFactor = curResolution.x / curResolution.y;

            var fieldPlane = UsedCamConfig.MaximumFiledValue - UsedCamConfig.MinimumFieldValue;
            var resPlane = UsedCamConfig.MinResolution - UsedCamConfig.MaxResolution;
            var resPercent = 1 - (screenFactor - UsedCamConfig.MaxResolution) / resPlane;
            var setField = fieldPlane * resPercent + UsedCamConfig.MinimumFieldValue;
            
            Cam.fieldOfView = setField;
        }
    }
}