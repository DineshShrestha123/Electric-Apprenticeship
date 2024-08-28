using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRCameraAdjuster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cameraOffset; // Reference to the camera offset GameObject
    private bool hasAdjustedOffset = false;

    void Update()
    {
        if (!hasAdjustedOffset && IsHeadsetWorn())
        {
            AdjustCameraOffset();
            hasAdjustedOffset = true; // Ensure the adjustment only happens once
        }
    }

    bool IsHeadsetWorn()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeadMounted, devices);

        foreach (var device in devices)
        {
            if (device.TryGetFeatureValue(CommonUsages.userPresence, out bool userPresent) && userPresent)
            {
                return true;
            }
        }
        return false;
    }
    void AdjustCameraOffset()
    {
        if (cameraOffset != null)
        {
            Vector3 newOffset = cameraOffset.transform.localPosition;
            newOffset.y = 2f; // Set Y offset to 2
            cameraOffset.transform.localPosition = newOffset;

            Debug.Log("Camera offset adjusted to y=2");
        }
        else
        {
            Debug.LogWarning("CameraOffset GameObject is not assigned.");
        }
    }
}