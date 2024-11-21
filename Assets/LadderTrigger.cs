using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LadderTrigger : MonoBehaviour
{
    public ContinuousMoveProviderBase moveProvider;

    public int taskNumber, taskCompletePercentage;

    private CharacterController characterController;
    public InputActionReference leftJoystickMoveAction;


    public int climbValue;
    public void LadderGrabbed()
    {
        if (taskNumber==0)
        {
            return;
        }
        TaskManagerCount.instance.TaskCompleted(taskNumber, taskCompletePercentage);
    }
    private void Start()
    {
       moveProvider = FindObjectOfType<ContinuousMoveProviderBase>();
        characterController = moveProvider.GetComponent<CharacterController>();

    }
    // Start is called before the first frame update
    //ladder samatyo
    public void DisableMovement()
    {
        Debug.Log("Ladder climbing");
        climbValue++;
        print("climb value is" + climbValue);
     moveProvider.moveSpeed = 0;
     moveProvider.useGravity = false;

    }

    public void EnableMovement()
    {
        climbValue--;
        print("climb value is" + climbValue);

        Debug.Log("Ladder deselected");
      if(climbValue == 0)
        {
            moveProvider.moveSpeed = 1.2f;
            moveProvider.useGravity = true;

        }

    }
   
}
