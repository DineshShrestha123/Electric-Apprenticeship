using GogoGaga.OptimizedRopesAndCables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        StartCoroutine(WaitAndChangeScene());

    }

    IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Scenario3");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
