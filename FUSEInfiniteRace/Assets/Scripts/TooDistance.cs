using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Due to floating point precision, we want to bound the player's position.
// This is a really hacky and bad way to do it, but for a small game like this, it's probably
// good enough.
public class TooDistance : MonoBehaviour
{
    Transform player;
    Scorer scorer;
    public float maxDist;
    public float warpDist;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        scorer = player.GetComponent<Scorer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= maxDist)
        {

            GameObject[] allObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject go in allObjects)
            {
                go.transform.position = new Vector3(go.transform.position.x - warpDist, go.transform.position.y, go.transform.position.z);
            }
            scorer.WarpAll(warpDist);
            GetComponent<SpawnObstacles>().Warp(warpDist);
            Debug.Log("Panic reset everyones position");
        }


    }
}
