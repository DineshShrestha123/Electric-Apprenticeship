using GogoGaga.OptimizedRopesAndCables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Scenario4SwitchSocketInteractor : XRSocketInteractor
{
 

    public int taskNumber;
    public int taskCompletePercentage;
    // Start is called before the first frame update
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        TaskManagerCount.instance.TaskCompleted(taskNumber, taskCompletePercentage);
        SceneManager.LoadScene("Scenario1New");
      

    }
    // Update is called once per frame
    void Update()
    {

    }
}
