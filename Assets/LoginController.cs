using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    [Header("LoginRelatedStuff")]
    public TMP_InputField email;
    public TMP_InputField password;
    public Button btn_proceed;
    public void onclickLoginButton()
    {
        print("login complete");
        print("email is" + email);
        print("password is" + password);
        UiCanvasController.instance.LoginInComplete();

    }
    // Start is called before the first frame update
    void Start()
    {
       // btn_proceed.GetComponent<Button>().onClick.AddListener(onclickLoginButton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
