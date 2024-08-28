using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManagerCount : MonoBehaviour
{
    public int currentTaskCount = 0;

    public static TaskManagerCount instance;
    public ScriptableListForTasks currentListOfTasks;

    [Header("Task Related GameObjects")]
    public GameObject ladder;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void TaskCompleted()
    {
        currentTaskCount++;
        if(currentTaskCount== 1)
        {
            ladder.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
