using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillMachine : IventoryObject
{

    public GameObject DrillNozzle;
    public float rotationForce;
    public bool isNozzleRotating;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelectedBool)
        {
/*            print("is selected" + isSelectedBool);
*/
            if (isLeftHandGrabbing)
            {
               float triggerButtonPressValue =  ActivateTeleportationRay.instance.leftActivate.action.ReadValue<float>();
                if (triggerButtonPressValue > 0.2f)
                {

                    DrillNozzle.transform.Rotate(0f, 0f, triggerButtonPressValue * rotationForce);
                    isNozzleRotating = true;
                }
                else {
                    isNozzleRotating = false;
                }

            }
            //righ hand is grabbing
            else
            {
                float triggerButtonPressValue = ActivateTeleportationRay.instance.rightActivate.action.ReadValue<float>();
                if (triggerButtonPressValue > 0.1f)
                {

                    DrillNozzle.transform.Rotate(0f, 0f, triggerButtonPressValue * rotationForce * Time.deltaTime);
                    isNozzleRotating = true;
                }
                else
                {
                    isNozzleRotating = false;
                }
            }
        }
    }
}
