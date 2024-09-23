using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UiCanvasController : MonoBehaviour
{
    [Header("AllCanvases")]
    public GameObject canvasForLogo;
    public GameObject canvasForLogin;
    public GameObject canvasForPreSecenario;
    public GameObject canvasForTopBar;
    public GameObject canvasForScenarioChoose;
    public GameObject canvasForIndividualScenario;
    public GameObject canvasForGameScenario;



    public static UiCanvasController instance;

    [Header("MenuActivateManual")]
    public InputActionProperty showButton;
    public Transform head;
    public float spawnDistance = 10;
    Scene currentScene;
    void Start()
    {
        instance = this;

         currentScene = SceneManager.GetActiveScene();

        Debug.Log("Current Scene: " + currentScene.name);
        if (!currentScene.name.Equals("Scenario1"))
        {
            return;
        }

            canvasForLogo.SetActive(true);
       
        Invoke(nameof(WaitAndDisablePanel), 8f);
    }
    void WaitAndDisablePanel()
    {
        canvasForLogo.SetActive(false);
        canvasForLogin.SetActive(true);

    }
    bool isTaskcomplete;
    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            if (currentScene.name.Equals("Scenario1"))
            {
                TaskManagerCount.instance.TaskCompleted(1, 100);

            }


            canvasForGameScenario.SetActive(!canvasForGameScenario.activeSelf);
            canvasForGameScenario.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized * spawnDistance;

        }
        canvasForGameScenario.transform.LookAt(new Vector3(head.position.x,canvasForGameScenario.transform.position.y,head.position.z));
        canvasForGameScenario.transform.forward *= -1;
    }

    public void LoginInComplete()
    {
        canvasForLogin.SetActive(false);
        canvasForPreSecenario.SetActive(true);
        canvasForTopBar.SetActive(true);
    }

    public void ActivateScenario()
    {
        print("activate scenario is called");
        canvasForPreSecenario.SetActive(false);
        canvasForScenarioChoose.SetActive(true);

    }

    public void ActivateIndividualScenario()
    {
        canvasForScenarioChoose.SetActive(false);
        //later need loop for this canvasforindividualscenario should be four+
        canvasForIndividualScenario.SetActive(true);
    }


    public void TrainThisScenarioActivateGameScene()
    {
        canvasForIndividualScenario.SetActive(false);
        canvasForGameScenario.SetActive(true);
    }

 
}
