using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CanvasController : MonoBehaviour
{
    public XRDirectInteractor directInteractor; // Reference to the XRDirectInteractor
    public IXRSelectInteractable selectInteractablke;
    public XRBaseInteractor baseInteractor;
    // Reference to the XRDirectInteractor
   // public XRDirectInteractor directInteractor; // Reference to the XRDirectInteractor
    public XRGrabInteractable grabInteractable; // The interactable object to be grabbed
    public XRInteractionManager interactionManager;
    // Start is called before the first frame update
    public void changeColorFromButtonScript()
    {
        int randomNumber = Random.Range(0, 10);
        print(randomNumber);
      //  interactionManager.ForceSelect(directInteractor, grabInteractable);
        interactionManager.SelectEnter(directInteractor, grabInteractable);
    }
 

  
}
