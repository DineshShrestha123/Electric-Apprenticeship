using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightedAreaScript : MonoBehaviour
{
    public int TaskId;
    private void OnTriggerEnter(Collider other)
    {
        TaskManagerCount.instance.TaskCompleted(TaskId, 100);
        gameObject.SetActive(false);
        
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
