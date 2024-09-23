using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarInteraction : RopeDetails
{

    [Header("Indicators")]
    public GameObject indicatorToDisable, indicatorToEnable;

    bool isRightSideCompleted= false;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider)
        {
            Debug.Log("Touched a BoxCollider: " + other.name);
        }
        // Check if the collider is a SphereCollider
        else
        {
            Debug.Log("Touched a capsule: " + other.name);
        }
        if (indicatorToDisable != null) {
            indicatorToDisable.SetActive(false);
        }
        if (indicatorToEnable != null) {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
