using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskListWithScenario", menuName = "ScriptableObjects/TasWithScenario")]
public class ScriptableListForTasks : ScriptableObject
{
    // Start is called before the first frame update
    public List<string> listOfTasks = new List<string>();
    public string scenarioName;
}
