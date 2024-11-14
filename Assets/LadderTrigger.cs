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
    public void DisableMovement()
    {
        Debug.Log("Ladder climbing");
      //  moveProvider.useGravity = false;
        moveProvider.enabled = false;
      
    }

    public void EnableMovement()
    {
        Debug.Log("Ladder deselected");
        //   moveProvider.useGravity = true;
        //  moveProvider.moveSpeed = 1.2f;

        //  moveProvider.enabled = true;
        StartCoroutine(ResumeMovementWithDelay());

    }
    private IEnumerator ResumeMovementWithDelay()
    {
        yield return new WaitForSeconds(0.01f); // Small delay to let other scripts finish
        if (moveProvider != null)
            moveProvider.enabled = true;
    }
}
