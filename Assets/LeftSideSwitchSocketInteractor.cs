using GogoGaga.OptimizedRopesAndCables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftSideSwitchSocketInteractor : XRSocketInteractor
{
    [Header("Indicators")]
    public GameObject indicatorToDisable, indicatorToEnable;
    public GameObject indicator;

    public Rope ropeToEnd;
    public Transform ropeStartPoint;
    public Transform ropeEndPointPoint;

    public GameObject LeftSideHighlightedArea, LeftSideGrabInteractablePosition;
    public Rope LeftSideInitialRope;
    public GameObject grabInteractable;
    public Transform leftSideRopeStartPosition;
    // Start is called before the first frame update
    [Header("TaskRelated")]
    public int taskNumber;
    public int taskCompletePercentage;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        TaskManagerCount.instance.TaskCompleted(taskNumber, taskCompletePercentage);
        if (indicatorToDisable != null)
        {
            indicatorToDisable.SetActive(false);
        }
        if (indicatorToEnable != null)
        {
            indicatorToEnable.SetActive(true);

        }
        ropeToEnd.StartPoint = ropeStartPoint;
        ropeToEnd.EndPoint = ropeEndPointPoint;
        // Call the base class implementation
        base.OnSelectEntered(args);

        // Print "Hello" when an object is selected
        Debug.Log("Hello");

        //LeftSide Related Stuff
        InventorySystem.instance.DeSelectObject(grabInteractable);
    /*    grabInteractable.transform.position = LeftSideGrabInteractablePosition.transform.position;
        LeftSideHighlightedArea.SetActive(true);
        LeftSideInitialRope.StartPoint = leftSideRopeStartPosition;
        LeftSideInitialRope.EndPoint = grabInteractable.transform;
        LeftSideInitialRope.gameObject.SetActive(true);
*/

    }
    // Update is called once per frame
    void Update()
    {

    }
}
