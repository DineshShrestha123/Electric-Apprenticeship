using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DrillablePlank : MonoBehaviour
{
    public Mesh[] meshesList;
    public int currentmeshcount;
    public GameObject indicator;
    // Start is called before the first frame update
    void Start()
    {
        currentmeshcount = 0;
    }
    bool isTouchingPlank;
    private void OnTriggerEnter(Collider other)
    {
        indicator.SetActive(false);
        isTouchingPlank = true;

    }

  


   
    private void OnTriggerExit(Collider other)
    {
        isTouchingPlank = false;

    }
    float timer;
    // Update is called once per frame
    void Update()
    {
        if (isTouchingPlank)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                timer = 0;
                currentmeshcount++;
                MeshFilter meshFilter = GetComponent<MeshFilter>();

                // Assign the new Mesh to the MeshFilter
                if (currentmeshcount == meshesList.Length-1) {
                    // GetComponent<BoxCollider>().enabled = false;
                    // 
                    TaskManagerCount.instance.TaskCompleted(5, 35);
                }

                if(currentmeshcount > meshesList.Length - 1)
                {
                    return;
                }
                meshFilter.mesh = meshesList[currentmeshcount];
            }
        }
        else
        {
            timer = 0;
        }
    }
}
