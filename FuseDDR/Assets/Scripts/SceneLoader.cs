using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    RectTransform mytransform;
    public bool left = true;

    private void Start()
    {
        mytransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            left = false;
            mytransform.anchoredPosition = new Vector3(150, -150,0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
            mytransform.anchoredPosition = new Vector3(-150, -150,0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (left)
                SceneManager.LoadScene("EasyScene", LoadSceneMode.Single);
            else
                SceneManager.LoadScene("HardScene", LoadSceneMode.Single);
        }
    }
}
