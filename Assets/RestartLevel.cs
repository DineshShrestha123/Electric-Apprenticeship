using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeScenario);
    }

    // Update is called once per frame
    void ChangeScenario()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
