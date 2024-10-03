using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarInteractionToEndTask : RopeDetails
{

    [Header("Indicators")]
    public GameObject indicatorToDisable, indicatorToEnable, LeftIndicatorToDisable, LeftIndicatorToEnable;

    bool isRightSide = true;
    // Start is called before the first frame update

    public int taskNumberForRight, taskCompletePercentageForRight;
    public int taskNumberForLeft, taskCompletePercentageForLeft;
    public void OnTriggerEnter(Collider other)
    {


        if (isRightSide)
        {
            TaskManagerCount.instance.TaskCompleted(taskNumberForRight, taskCompletePercentageForRight);
            isRightSide = false;
            if (indicatorToDisable != null)
            {
                indicatorToDisable.SetActive(false);
            }
            if (indicatorToEnable != null)
            {
                indicatorToEnable.SetActive(true);

            }

            print("trigger is called");
            ropeToEnd.StartPoint = ropeToEndStartPos;
            ropeToEnd.EndPoint = ropeToEndFinalPos;
            if (ropeToEndMiddlePos != null)
            {
                ropeToEnd.MidPoint = ropeToEndMiddlePos;
            }

            InventorySystem.instance.DeSelectObject(grabInteractable);
            ropeToCreateNew.StartPoint = ropeToCreateStartPos;

            grabInteractable.transform.position = grabInteractablePos.position;
            grabInteractable.GetComponent<Rigidbody>().isKinematic = true;
            ropeToCreateNew.EndPoint = grabInteractable.transform;

            ropeToCreateNew.gameObject.SetActive(true);



        }
      



    }

    // Update is called once per frame
    void Update()
    {

    }
}
