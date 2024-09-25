using GogoGaga.OptimizedRopesAndCables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMiddleLog : RopeDetails
{
    // Start is called before the first frame update
    [Header("Indicators")]
    public GameObject indicatorToDisable, indicatorToEnable;

    public GameObject ropeStaticFacingDown;
    int triggerCount;


    [Header("Rope to StartSecond")]
    public Rope ropeBelowMiddleLog;
    public Transform ropeBelowMiddleStartPos;
    public Transform ropeBelowMiddleLogFinalPos;

    [Header("InteractionPoint")]
    public GameObject highlightedArea;

    bool letTrigger = true;

    [Header("TaskRelated")]
    public int taskNumber;
    public int taskCompletePercentage;
    public void OnTriggerEnter(Collider other)
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
        if (!letTrigger) return;
        letTrigger = false;
        ropeToEnd.StartPoint = ropeToEndStartPos;
        ropeToEnd.EndPoint = ropeToEndFinalPos;
        if (ropeToEndMiddlePos != null)
        {
            ropeToEnd.MidPoint = ropeToEndMiddlePos;
        }

        ropeStaticFacingDown.SetActive(true);
        GetComponent<LeftMiddleLog>().enabled = false;
        //enable after 2 seconds coz trigger is immediatley called in other script so wating
        GetComponent<LeftMiddleLogSecondTrigger>().EnableComponent();

        ropeBelowMiddleLog.StartPoint = ropeBelowMiddleStartPos;
        InventorySystem.instance.DeSelectObject(grabInteractable);

        grabInteractable.transform.position = ropeBelowMiddleLogFinalPos.transform.position;
        //GetComponent<BoxCollider>().enabled = true;

        ropeBelowMiddleLog.EndPoint = grabInteractable.transform;
       // highlightedArea.SetActive(true);
        ropeBelowMiddleLog.gameObject.SetActive(true);
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
