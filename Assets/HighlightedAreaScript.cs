using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightedAreaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TaskManagerCount.instance.TaskCompleted(1,100);
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
