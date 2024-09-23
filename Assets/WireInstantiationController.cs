using GogoGaga.OptimizedRopesAndCables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WireInstantiationController : MonoBehaviour
{
    public static WireInstantiationController instance; 
    // Start is called before the first frame update

    //PVc till 
    public List<WireDetailsWithPillar> listOfWireDetailsWithPillar = new List<WireDetailsWithPillar>();
    public Dictionary<int, WireDetailsWithPillar> dictionaryForWireDetailsFromPillar = new Dictionary<int, WireDetailsWithPillar>();

    [Header("RopeRelatedStff")]
    public GameObject ropePrefabToInstantiate;

    [Header("FirstRopeRelatedStff")]

    public Rope firstRope,secondRope;
    public Transform firstRopeEndPoint;

    public GameObject grabInteractable;
    GameObject ropeNew;
    public void StartWireInstantiation(int pillarNo)
    {
        print("current pillar no is"+pillarNo);
        WireDetailsWithPillar wireDetails = dictionaryForWireDetailsFromPillar[pillarNo];
        //find rope to end
        RopeData ropeToEndData = wireDetails.RopeToEnd;
        RopeData ropeToBeginData = wireDetails.RopeToBegin;
        //it is already activate so no need to setactive just set the  values
        Rope ropeToEnd = ropeToEndData.rope.GetComponent<Rope>();
        ropeToEnd.StartPoint = ropeToEndData.ropeStartPoint.transform;
        ropeToEnd.EndPoint = ropeToEndData.ropeEndPoint.transform;
        if (ropeToEndData.ropeMidPoint != null)
        {
            ropeToEnd.MidPoint = ropeToEndData.ropeMidPoint.transform;
        }
        //need to activate second rope and also grab interactable needs to changed deselected first then set position 
        Rope ropeToBegin = ropeToBeginData.rope.GetComponent<Rope>();
        InventorySystem.instance.DeSelectObject(grabInteractable);
        //after object has been deselected put the grab interactable in the position of 
        grabInteractable.transform.position = ropeToBeginData.ropeEndPoint.transform.position;
        grabInteractable.GetComponent<Rigidbody>().isKinematic = true;

        ropeToBegin.StartPoint = ropeToBeginData.ropeStartPoint.transform;
        ropeToBegin.EndPoint = grabInteractable.transform;
        ropeToBegin.gameObject.SetActive(true);

        TaskManagerCount.instance.TaskCompleted(1, 25);
      /*  if (pillarNo == 1)
        {
            WireDetailsWithPillar wireDetails = dictionaryForWireDetailsFromPillar[pillarNo];
            //find rope to end
            RopeData ropeToEndData = wireDetails.RopeToEnd;
            RopeData ropeToBeginData = wireDetails.RopeToBegin;
            //it is already activate so no need to setactive just set the  values
            Rope ropeToEnd = ropeToEndData.rope.GetComponent<Rope>();
            ropeToEnd.StartPoint = ropeToEndData.ropeStartPoint.transform;
            ropeToEnd.EndPoint = ropeToEndData.ropeEndPoint.transform;
            if(ropeToEndData.ropeMidPoint != null) {
                ropeToEnd.MidPoint = ropeToEndData.ropeMidPoint.transform;
            }
            //need to activate second rope and also grab interactable needs to changed deselected first then set position 
            Rope ropeToBegin = ropeToBeginData.rope.GetComponent<Rope>();
            InventorySystem.instance.DeSelectObject(grabInteractable);
            //after object has been deselected put the grab interactable in the position of 
            grabInteractable.transform.position= ropeToBeginData.ropeEndPoint.transform.position;
            grabInteractable.GetComponent<Rigidbody>().isKinematic = true;    

            ropeToBegin.StartPoint = ropeToBeginData.ropeStartPoint.transform;
            ropeToBegin.EndPoint = grabInteractable.transform;
            ropeToBegin.gameObject.SetActive(true);
          
        }
       */

    }

    public void StartWireInstantiationPVC2Point5(int pillarNo)
    {

    }

    // Update is called once per frame
    void Start()
    {
        instance = this;
        foreach (WireDetailsWithPillar wd in listOfWireDetailsWithPillar)
        {
            dictionaryForWireDetailsFromPillar.Add(wd.pillarNumber,wd);
        }
    }
}
[Serializable]
public class WireDetailsWithPillar
{
    public int pillarNumber;
    public RopeData RopeToEnd;
    public RopeData RopeToBegin;


}

[Serializable]

public class RopeData
{
    public GameObject ropeStartPoint;
    public GameObject rope;
    public GameObject ropeEndPoint;
    public GameObject ropeMidPoint;
}

