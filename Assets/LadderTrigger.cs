using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{

    public int taskNumber, taskCompletePercentage;
    public void LadderGrabbed()
    {
        TaskManagerCount.instance.TaskCompleted(taskNumber, taskCompletePercentage);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
