using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightedAreaScript : MonoBehaviour
{
    public int TaskId,taskCompletePercentage;
    private void OnTriggerEnter(Collider other)
    {
        print("gameobj name"+gameObject.name);
        gameObject.SetActive(false);

        TaskManagerCount.instance.TaskCompleted(TaskId, taskCompletePercentage);
        
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
