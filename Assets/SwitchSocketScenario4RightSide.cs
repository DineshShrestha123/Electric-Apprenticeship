using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchSocketScenario4RightSide : XRSocketInteractor
{
    // Start is called before the first frame update
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        print("scene over");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
