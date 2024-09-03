using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TaskListWithScenario", menuName = "ScriptableObjects/TasWithScenario")]
public class ScriptableListForTasks : ScriptableObject
{
    // Start is called before the first frame update
    public List<string> listOfTasks = new List<string>();
    public string scenarioName;
    public List<Task> taskList;
}

[Serializable]
public class Task
{
    public string TaskName;
    public string TaskDetails;
    public float TaskCompletePercentage;
    public int TaskNumber;
    public bool isCompleted;
    public bool hasDetails;
}

[System.Serializable]
public class TaskCompleteEvent : UnityEvent<int, int, int>
{
}