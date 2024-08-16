using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject partPrefab, parentObject;

    [SerializeField]
    [Range(1, 1000)]
    int length = 1;

    [SerializeField]
    float partDistance = 0.21f;


    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (reset)
        {
            foreach (GameObject t in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(t);
            }
            reset = false;
        }

        if (spawn)
        {
            Spawn();
            spawn = false;
        }
    }

    public void Spawn()
    {
        int count = (int)(length / partDistance);
        for (int i = 0; i < count; i++)
        {
            GameObject tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.name =  parentObject.transform.childCount.ToString();
         //   tmp.transform.eulerAngles = new Vector3(180, 0, 0);
            if(i == 0)
            {
               // Destroy(tmp.GetComponent<CharacterJoint>());
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount -1).ToString()).GetComponent<Rigidbody>();
            }
        
        }
    }
}
