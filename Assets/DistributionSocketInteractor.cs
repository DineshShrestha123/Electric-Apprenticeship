using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributionSocketInteractor : MonoBehaviour
{
    public GameObject highlightedAreaForWoodenPlank;
    public void DistributionBoardSocketInteraction()
    {
        highlightedAreaForWoodenPlank.SetActive(true);
        TaskManagerCount.instance.TaskCompleted(6, 100);
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
