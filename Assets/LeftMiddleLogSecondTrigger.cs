using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftMiddleLogSecondTrigger : RopeDetails
{
    [Header("Indicators")]
    public GameObject indicatorToDisable, indicatorToEnable;
    public bool letTrigger = false;

    [Header("TaskRelated")]
    public int taskNumber;
    public int taskCompletePercentage;
    public void OnTriggerEnter(Collider other)
    {
        TaskManagerCount.instance.TaskCompleted(taskNumber, taskCompletePercentage);

        print("trigger is called");

        if (indicatorToDisable != null)
        {
            indicatorToDisable.SetActive(false);
        }
        if (indicatorToEnable != null)
        {
            indicatorToEnable.SetActive(true);

        }
        if (letTrigger)
        {
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


    public void EnableComponent()
    {
        StartCoroutine(CoroutineEnableComponent());
    }

    public IEnumerator CoroutineEnableComponent()
    {

        yield return new WaitForSeconds(3f);
        letTrigger = true;
        GetComponent<LeftMiddleLogSecondTrigger>().enabled = true;

    }
}
