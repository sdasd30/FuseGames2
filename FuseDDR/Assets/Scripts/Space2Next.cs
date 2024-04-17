using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Space2Next : MonoBehaviour
{
    public string sceneLoadName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneLoadName, LoadSceneMode.Single);
        }
    }
}
