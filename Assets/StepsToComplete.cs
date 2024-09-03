using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StepsToComplete : MonoBehaviour
{
    // Start is called before the first frame update
    public ScriptableListForTasks taskWithScenario;
    public GameObject prefabToInstantiate,content;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        foreach (var item in taskWithScenario.taskList)
        {
          var go =  Instantiate(prefabToInstantiate, content.transform);
            go.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = item.TaskName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
