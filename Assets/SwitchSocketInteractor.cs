using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using GogoGaga.OptimizedRopesAndCables;

public class SwitchSocketInteractor : XRSocketInteractor
{

    public GameObject indicator;

    public Rope ropeToEnd;
    public Transform ropeStartPoint;
    public Transform ropeEndPointPoint;

    public GameObject LeftSideHighlightedArea,LeftSideGrabInteractablePosition;
    public Rope LeftSideInitialRope;
    public GameObject grabInteractable;
    public Transform leftSideRopeStartPosition;
    // Start is called before the first frame update
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (indicator != null) {
            indicator.SetActive(false);

        }
        ropeToEnd.StartPoint = ropeStartPoint;
        ropeToEnd.EndPoint = ropeEndPointPoint;
        // Call the base class implementation
        base.OnSelectEntered(args);

        // Print "Hello" when an object is selected
        Debug.Log("Hello");
        TaskManagerCount.instance.TaskCompleted(1, 25);

        //LeftSide Related Stuff
        InventorySystem.instance.DeSelectObject(grabInteractable);
        grabInteractable.transform.position = LeftSideGrabInteractablePosition.transform.position;
        LeftSideHighlightedArea.SetActive(true);
        LeftSideInitialRope.StartPoint = leftSideRopeStartPosition;
        LeftSideInitialRope.EndPoint = grabInteractable.transform;
        LeftSideInitialRope.gameObject.SetActive(true);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
