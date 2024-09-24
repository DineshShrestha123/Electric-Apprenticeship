using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarInteraction : RopeDetails
{

    [Header("Indicators")]
    public GameObject indicatorToDisable, indicatorToEnable,LeftIndicatorToDisable,LeftIndicatorToEnable;

    bool isRightSide = true;
    // Start is called before the first frame update

    
    public void OnTriggerEnter(Collider other)
    {
       

        if (isRightSide) {

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

            ropeToCreateNew.StartPoint = ropeToCreateStartPos;
            InventorySystem.instance.DeSelectObject(grabInteractable);

            grabInteractable.transform.position = grabInteractablePos.position;
            grabInteractable.GetComponent<Rigidbody>().isKinematic = true;
            ropeToCreateNew.EndPoint = grabInteractable.transform;

            ropeToCreateNew.gameObject.SetActive(true);



        }
        else
        {
            if (LeftIndicatorToDisable != null)
            {
                LeftIndicatorToDisable.SetActive(false);
            }
            if (LeftIndicatorToEnable != null)
            {
                LeftIndicatorToEnable.SetActive(true);

            }

            print("trigger is called");
            ropeLeftToEnd.StartPoint = ropeLeftToEndStartPos;
            ropeLeftToEnd.EndPoint = ropeLeftToEndFinalPos;
           /* if (ropeToEndMiddlePos != null)
            {
                ropeToEnd.MidPoint = ropeToEndMiddlePos;
            }*/

            ropeLeftToCreateNew.StartPoint = ropeLeftToCreateStartPos;
            InventorySystem.instance.DeSelectObject(grabInteractable);

            grabInteractable.transform.position = grabInteractableLeftPos.position;
            grabInteractable.GetComponent<Rigidbody>().isKinematic = true;
            ropeLeftToCreateNew.EndPoint = grabInteractable.transform;

            ropeLeftToCreateNew.gameObject.SetActive(true);

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
