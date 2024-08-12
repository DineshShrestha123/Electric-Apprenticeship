using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InventoryUi : MonoBehaviour, IPointerEnterHandler
{
    // Start is called before the first frame update
    private XRUIInputModule GetXRInputModule() => EventSystem.current.currentInputModule as XRUIInputModule;

    private bool TryGetXRRayInteractor(int pointerID, out XRRayInteractor rayInteractor)
    {
        var inputModule = GetXRInputModule();
        if (inputModule == null)
        {
            rayInteractor = null;
            return false;
        }

        rayInteractor = inputModule.GetInteractor(pointerID) as XRRayInteractor;
        return rayInteractor != null;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        print("pointer enter is called");
        if (TryGetXRRayInteractor(eventData.pointerId, out var rayInteractor))
        {
            print("ray interactor gameobject name" + rayInteractor.name);
            if (rayInteractor.name.Contains("Right"))
            {
                InventorySystem.instance.GrabTheObjectFromUiClick(gameObject.name, true);
            }
            else
            {
                InventorySystem.instance.GrabTheObjectFromUiClick(gameObject.name, false);

            }
            rayInteractor.SendHapticImpulse(5, 2f);
        }
    }


}
