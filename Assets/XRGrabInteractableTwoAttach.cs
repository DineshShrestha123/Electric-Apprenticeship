using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;
    public bool isSelectedBool = false;
    public bool isLeftHandGrabbing;
    public bool isRightHandGrabbing;

    GameObject handRefrence;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        isSelectedBool = true;
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            handRefrence= args.interactorObject.transform.GetChild(0).gameObject;
            handRefrence.SetActive(false);
            isLeftHandGrabbing = true;
            ActivateGrabRay.instance.isLeftHandGrabbing = true;
            attachTransform = leftAttachTransform;
        }
        else
        {
            handRefrence = args.interactorObject.transform.GetChild(0).gameObject;
            handRefrence.SetActive(false);

            ActivateGrabRay.instance.isRightHandGrabbing = true;
            isRightHandGrabbing = true;
            attachTransform = rightAttachTransform;

        }
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        isSelectedBool = false;

        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {

            ActivateGrabRay.instance.isLeftHandGrabbing = false;
            isLeftHandGrabbing = false;

            attachTransform = leftAttachTransform;
            handRefrence.SetActive(true);

        }
        else
        {
            ActivateGrabRay.instance.isRightHandGrabbing = false;
            isRightHandGrabbing = false;

            attachTransform = rightAttachTransform;
            handRefrence.SetActive(true);

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
