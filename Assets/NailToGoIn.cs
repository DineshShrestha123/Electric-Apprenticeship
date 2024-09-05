using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailToGoIn : MonoBehaviour
{
    bool isTouchingPlank;
    public float movementSpeed = 0.01f;  // Speed at which the nail moves along the X-axis
    public float rotationSpeed = 5f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        print("collider enterd in nail");
        isTouchingPlank = true;

    }
    private void OnTriggerExit(Collider other)
    {
        isTouchingPlank = false;

    }
    float timer;
    int countToLetDrill = 1;
    void Update()
    {
        if (isTouchingPlank)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {


                print("counter drill"+ countToLetDrill);
                 countToLetDrill++;
               /* if (countToLetDrill == 17) {

                    TaskManagerCount.instance.TaskCompleted(8, 50);
                }*/
                TaskManagerCount.instance.TaskCompleted(8, 50);

                // Move the nail slowly along the X-axis
                transform.position += new Vector3(-movementSpeed, 0, 0);

                // Rotate the nail slowly
                transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
                
                timer = 0; // Reset the timer for the next interval
            }
        }
        else
        {
            timer = 0;
        }
    }
}
