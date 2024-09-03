using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TaskManagerCount : MonoBehaviour
{
    public int currentTaskCount = 0;

    public static TaskManagerCount instance;
    public ScriptableListForTasks currentListOfTasks;

    [Header("Task Related GameObjects")]
    public GameObject ladder;
    public GameObject taskInstantiatedContentParent;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void TaskCompleted(int TaskNumber,float completePercentage)
    {
        Task task = currentListOfTasks.taskList.FirstOrDefault(task => task.TaskNumber == TaskNumber);

        task.TaskCompletePercentage += completePercentage;
        if (task.TaskCompletePercentage > 90 || task.TaskCompletePercentage > 100)
        {
            //tick the complete task in ui 
            int childIndex = TaskNumber - 1;
            taskInstantiatedContentParent.transform.GetChild(childIndex).transform.gameObject.transform.GetChild(1).GetComponent<Toggle>().isOn= true;
        }
        else
        {
          

        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
