using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public Image imageForButton;
    // Start is called before the first frame update
    public void changeColorFromButtonScript()
    {
        int randomNumber = Random.Range(0, 10);
        print("random number"+randomNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
