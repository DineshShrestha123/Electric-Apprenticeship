using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRayInteractor;
    public GameObject rightGrabRayInteractor;
    public InputActionProperty leftSelect;
    public InputActionProperty rightSelect;

    public bool isRightHandGrabbing;
    public bool isLeftHandGrabbing;

    public static ActivateGrabRay instance;
    public XRBaseInteractor leftInteractor;
    public XRBaseInteractor rightInteractor;
    public void Awake()
    {
        instance = this;
    }
    void Update()
    {
/*        bool isLeftHandGrabbing = leftInteractor.hasSelection;
*/

        leftGrabRayInteractor.SetActive(leftSelect.action.ReadValue<float>() > 0.1f);
        rightGrabRayInteractor.SetActive(rightSelect.action.ReadValue<float>() > 0.1f);
    }
}
