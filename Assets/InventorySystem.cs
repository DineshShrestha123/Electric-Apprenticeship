using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
            dynamicBtn.transform.GetChild(1).GetComponent<TMP_Text>().text = item.inventoryName;
            dynamicBtn.transform.GetChild(0).GetComponent<Image>().sprite = item.inventoryItemWithData.imageForUi;
        }
    }
    public XRInteractionManager interactionManager;
    public XRDirectInteractor directRightInteractor, directLeftInteractor;

    public bool isLadderSelectedFirstTime;
    public void GrabTheObjectFromUiClick(string gameobjectName,bool isRightHand)
    {
        print("gameobject name is" + gameobjectName);
        Scene currentScene = SceneManager.GetActiveScene();
        print("current scenario name is" + currentScene);
        if (gameobjectName.Equals("Ladder"))
        {
            if (!isLadderSelectedFirstTime && currentScene.name.Equals("Scenario2") || currentScene.name.Equals("Scenario1"))
            {
                isLadderSelectedFirstTime = true;
                TaskManagerCount.instance.TaskCompleted(3, 100);
            }
            GameObject ladder = dictionaryInventoryItems[gameobjectName].inventoryGameObject;
            ladder.SetActive(true);
            GameObject cameraoffset = GameObject.Find("Camera Offset");
           
            ladder.transform.position = UiCanvasController.instance.head.position + new Vector3(UiCanvasController.instance.head.forward.x, 0, UiCanvasController.instance.head.forward.z).normalized * 3;
            ladder.transform.LookAt(new Vector3(UiCanvasController.instance.head.position.x, ladder.transform.position.y, UiCanvasController.instance.head.position.z));
            //  ladder.transform.position = cameraoffset.transform.position + cameraoffset.transform.forward* 2;
            ladder.transform.position = new Vector3(ladder.transform.position.x, 0, ladder.transform.position.z);
            return;
        }


        GameObject gameObjToGrab = dictionaryInventoryItems[gameobjectName].inventoryGameObject;
        gameObjToGrab.SetActive(true);
        if (isRightHand)
        {
            interactionManager.SelectEnter(directRightInteractor, gameObjToGrab.GetComponent<XRGrabInteractableTwoAttach>());

        }
        else
        {
            interactionManager.SelectEnter(directLeftInteractor, gameObjToGrab.GetComponent<XRGrabInteractableTwoAttach>());

        }

    }

    public void DeSelectObject(GameObject grabInteractable)
    {
        print("deselect is called");
        XRGrabInteractable interactable = grabInteractable.GetComponent<XRGrabInteractable>();
        if (interactable == null)
        {
            Debug.LogError("No XRGrabInteractable component found on the GameObject.");
            return;
        }

        // Get the currently selecting interactor
        XRBaseInteractor interactor = interactable.selectingInteractor;
        if (interactor == null)
        {
            Debug.Log("No interactor is currently selecting this interactable.");
            return;
        }

        // Deselect the interactable using the interaction manager
        interactionManager.SelectExit(interactor, interactable);
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
    public Sprite imageForUi;
}


