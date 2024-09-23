using GogoGaga.OptimizedRopesAndCables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleLog : RopeDetails
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
    public void OnTriggerEnter(Collider other)
    {
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
        GetComponent<MiddleLog>().enabled = false;
        GetComponent<MiddleLogSecondTrigger>().EnableComponent(); 

        ropeBelowMiddleLog.StartPoint = ropeBelowMiddleStartPos;
        InventorySystem.instance.DeSelectObject(grabInteractable);

        grabInteractable.transform.position = ropeBelowMiddleLogFinalPos.transform.position;
        //GetComponent<BoxCollider>().enabled = true;

        ropeBelowMiddleLog.EndPoint = grabInteractable.transform;
        highlightedArea.SetActive(true);
        ropeBelowMiddleLog.gameObject.SetActive(true);
    }

    public 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
