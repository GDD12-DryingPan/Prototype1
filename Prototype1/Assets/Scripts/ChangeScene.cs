using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string destination;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneSwitcher.HitPoints = 100;
            SceneManager.LoadScene(destination);
        }
    }
}
