using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MountSocketInteractor : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> nails = new List<GameObject>();
    public void MountSocketInteraction()
    {
        TaskManagerCount.instance.TaskCompleted(9, 100);
        SceneManager.LoadScene("Scenario2");
    }
    void Start()
    {
        foreach (GameObject obj in nails)
        {
            obj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
