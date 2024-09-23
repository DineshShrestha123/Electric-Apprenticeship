using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public int TaskId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
