using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireInteractablePillar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int pillarNumber;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        WireInstantiationController.instance.StartWireInstantiation(pillarNumber);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

