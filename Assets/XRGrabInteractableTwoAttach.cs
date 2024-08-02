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

            attachTransform = leftAttachTransform;
        }
        else
        {

            attachTransform = rightAttachTransform;

        }
        base.OnSelectEntered(args);
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
