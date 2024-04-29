using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneLoader : MonoBehaviour
{
    RectTransform mytransform;
    public bool up = true;

    private void Start()
    {
        mytransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            up = false;
            mytransform.anchoredPosition = new Vector3(0, -80, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            up = true;
            mytransform.anchoredPosition = new Vector3(0, -15, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (up)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            else
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
