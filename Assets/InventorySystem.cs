using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class InventorySystem : MonoBehaviour
{
    public List<InventoryData> inventoryData = new List<InventoryData>();
    private Dictionary<string, InventoryItem> dictionaryInventoryItems = new Dictionary<string, InventoryItem>();
    public static InventorySystem instance;
    [Header("InventoryUi")]
    public GameObject parentUI;


    public GameObject buttonDyanmicForInstantiation;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        foreach (var item in inventoryData)
        {

           dictionaryInventoryItems.Add(item.inventoryName, item.inventoryItemWithData);

            GameObject dynamicBtn =  Instantiate(buttonDyanmicForInstantiation, parentUI.transform);
            dynamicBtn.name = item.inventoryName;
            dynamicBtn.transform.GetChild(0).GetComponent<TMP_Text>().text = item.inventoryName;
        }
    }
    public XRInteractionManager interactionManager;
    public XRDirectInteractor directRightInteractor, directLeftInteractor;
    public void GrabTheObjectFromUiClick(string gameobjectName,bool isRightHand)
    {

        GameObject gameObjToGrab = dictionaryInventoryItems[gameobjectName].inventoryGameObject;
        if (isRightHand)
        {
            interactionManager.SelectEnter(directRightInteractor, gameObjToGrab.GetComponent<XRGrabInteractableTwoAttach>());

        }
        else
        {
            interactionManager.SelectEnter(directLeftInteractor, gameObjToGrab.GetComponent<XRGrabInteractableTwoAttach>());

        }

    }
    // Update is called once per frame

}

[Serializable]
public class InventoryData
{
    public string inventoryName;
    public InventoryItem inventoryItemWithData;

  //  public InventoryItem inventoryItem;
}

[Serializable]
public class InventoryItem
{
    public GameObject inventoryGameObject;
}


