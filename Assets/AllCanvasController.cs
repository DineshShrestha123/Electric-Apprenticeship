using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("AllCanvases")]
    public GameObject canvasForLogo;
    public GameObject canvasForLogin;
    public GameObject canvasForGameScene;
    public GameObject canvasForTopBar;
    public GameObject canvasForScenario;

    public static AllCanvasController instance;
    void Start()
    {
        instance = this;
        canvasForLogo.SetActive(true);
        canvasForLogin.SetActive(false);
        Invoke(nameof(WaitAndDisablePanel), 8f);
    }
    void WaitAndDisablePanel()
    {
        canvasForLogo.SetActive(false);
        canvasForLogin.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginInComplete()
    {
        canvasForLogin.SetActive(true);
        canvasForGameScene.SetActive(true);
        canvasForTopBar.SetActive(true);
    }

    public void ActivateScenario()
    {
        print("activate scenario is called");
        canvasForGameScene.SetActive(false);
        canvasForScenario.SetActive(true);

    }

}
