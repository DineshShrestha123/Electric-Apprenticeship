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
        isTouchingPlank = true;
        print("other gameobjectnameis" + other.gameObject.name);
        drillNozzle = other.gameObject;
        drillMachine = drillNozzle.GetComponentInParent<DrillMachine>();
    }




    GameObject drillNozzle;


    DrillMachine drillMachine;
  
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

            if (!drillMachine.isNozzleRotating)
            {
                return;
            }
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
                    indicator.SetActive(false);

                }

                if (currentmeshcount > meshesList.Length - 1)
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
