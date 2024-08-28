using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WireComponent : XRGrabInteractableTwoAttach
{
    // Start is called before the first frame update
    public XRGrabInteractable grabInteractable;
    public Rigidbody[] rigidbodies;

    private bool isGrabbed = false;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        PrintNamesRecursively(transform);

    }
    void PrintNamesRecursively(Transform parent)
    {
        // Print the name of the current GameObject
        Debug.Log(parent.name);
        
        // Recursively print the names of all children
        foreach (Transform child in parent)
        {
            PrintNamesRecursively(child);
        }
    }
    private void Update()
    {
        if (isSelectedBool)
        {
            print("Grabbed");
                foreach (Rigidbody rb in rigidbodies)
                {
                /*if (rb != rigidbodies[0])
                {
                    rb.isKinematic = true;
                }*/
                print("Grabbed"+ rb.gameObject.transform.GetSiblingIndex());

                if (rb.gameObject.transform.GetSiblingIndex() != 0)
                {
                    rb.isKinematic = true;
                }
            }
            
        }
        else
        {
          
                foreach (Rigidbody rb in rigidbodies)
                {
                    if (rb != rigidbodies[0])
                    {
                        rb.isKinematic = false;
                    }
                }
            
        }
    }
}