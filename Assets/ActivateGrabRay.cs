using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRayInteractor;
    public GameObject rightGrabRayInteractor;
    public InputActionProperty leftSelect;
    public InputActionProperty rightSelect;
 
    void Update()
    {

        leftGrabRayInteractor.SetActive(leftSelect.action.ReadValue<float>() > 0.1f);
        rightGrabRayInteractor.SetActive(rightSelect.action.ReadValue<float>() > 0.1f);
    }
}
