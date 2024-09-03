using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlankSocketInteractor : XRSocketInteractor
{

   public  List<GameObject> listOfNails = new List<GameObject>();
    public GameObject woodenPlankWithSocketInteractor;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        print("interactor object name" + args.interactorObject.transform.gameObject.name);

        XRGrabInteractable grabInteractable = args.interactableObject as XRGrabInteractable;

        if (grabInteractable != null)
        {
            // Print the name of the grab interactable object
            Debug.Log("GrabInteractable Object Selected: " + grabInteractable.name);
            grabInteractable.gameObject.SetActive(false);
        }
   
        woodenPlankWithSocketInteractor.SetActive(true);


        base.OnSelectEntered(args);
    }
    public  void PlankPlacedComplete()
    {
        //set all nails active
        print("plank placed complete is called");
      /*  foreach (GameObject obj in listOfNails) { 
        
        obj.SetActive(true);
        
        }*/
        
      


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
