using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Update is called once per frame
    public GameObject gameplayUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<PlayerMovement>().transform.position = new Vector3(0,.71f, 0);
            FindObjectOfType<SpawnObstacles>().active = true;
            FindObjectOfType<Scorer>().refPos = 0;
            gameplayUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
