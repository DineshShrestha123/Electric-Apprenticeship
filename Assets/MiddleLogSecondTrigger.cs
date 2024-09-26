using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleLogSecondTrigger : RopeDetails
{
    // Start is called before the first frame update
    [Header("Indicators")]
    public GameObject indicatorToDisable, indicatorToEnable;
    public bool letTrigger = false;

    [Header("TaskRelated")]
    public int taskNumber;
    public int taskCompletePercentage;
    public void OnTriggerEnter(Collider other)
    {
        print("trigger is called");
        TaskManagerCount.instance.TaskCompleted(taskNumber, taskCompletePercentage);

    
        if (letTrigger)
        {

            if (indicatorToDisable != null)
            {
                indicatorToDisable.SetActive(false);
            }
            if (indicatorToEnable != null)
            {
                indicatorToEnable.SetActive(true);

            }
            ropeToEnd.StartPoint = ropeToEndStartPos;
            ropeToEnd.EndPoint = ropeToEndFinalPos;
            if (ropeToEndMiddlePos != null)
            {
                ropeToEnd.MidPoint = ropeToEndMiddlePos;
            }

            ropeToCreateNew.StartPoint = ropeToCreateStartPos;

            InventorySystem.instance.DeSelectObject(grabInteractable);


            grabInteractable.transform.position = grabInteractablePos.position;
            grabInteractable.GetComponent<Rigidbody>().isKinematic = true;
            ropeToCreateNew.EndPoint = grabInteractable.transform;

            ropeToCreateNew.gameObject.SetActive(true);
        }
    }


    public void EnableComponent(GameObject middleLogBottomIndicator)
    {
        StartCoroutine(CoroutineEnableComponent(middleLogBottomIndicator));
    }

    public IEnumerator CoroutineEnableComponent(GameObject middleLogBottomIndicator)
    {

        yield return new WaitForSeconds(3f);
        letTrigger = true;
        middleLogBottomIndicator.SetActive(true);
        GetComponent<MiddleLogSecondTrigger>().enabled = true;

    }
}
