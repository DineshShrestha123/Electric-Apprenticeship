using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;
    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;
    // Start is called before the first frame update

    public XRRayInteractor leftRayInteractor;
    public XRRayInteractor rightRayInteractor;

    void Update()
    {
        //left interactor is grab select value
        bool isLeftRayHovering = leftRayInteractor.TryGetHitInfo(out Vector3 leftpos, out Vector3 leftNormal,out int leftNumber,out bool leftValid);
        leftTeleportation.SetActive(!isLeftRayHovering && leftActivate.action.ReadValue<float>() > 0.1f);

        bool isRightRayHovering = rightRayInteractor.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);


        rightTeleportation.SetActive(!isRightRayHovering && rightActivate.action.ReadValue<float>() > 0.1f);
    }

}
