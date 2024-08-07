using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            ActivateGrabRay.instance.isLeftHandGrabbing = true;
            attachTransform = leftAttachTransform;
        }
        else
        {
            ActivateGrabRay.instance.isRightHandGrabbing = true;

            attachTransform = rightAttachTransform;

        }
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {

        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {

            ActivateGrabRay.instance.isLeftHandGrabbing = false;

            attachTransform = leftAttachTransform;
        }
        else
        {
            ActivateGrabRay.instance.isRightHandGrabbing = false;

            attachTransform = rightAttachTransform;

        }

        base.OnSelectExited(args);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
