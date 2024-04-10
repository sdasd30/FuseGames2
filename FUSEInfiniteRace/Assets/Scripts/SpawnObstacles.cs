using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> obstacles;

    public bool active = false;
    public float XOffset;
    public float YOffset;
    public float maxZOffset;
    public float ZOffset;
    public float distanceToTravel = 20f;
    public float difficultyModifier = 3f;
    float currentGoal = 0f;

    private Queue<int> recentlySpawned;
    private int spawnInRow = 0;
    private float overrideZOffset;
    private int nextSpawn = 1;
    private float lastSpawnedZ = 0f;
    // Update is called once per frame

    private void Start()
    {
        currentGoal = this.transform.position.x + distanceToTravel;
        recentlySpawned = new Queue<int>();
        recentlySpawned.Enqueue(3);
        recentlySpawned.Enqueue(4);
        recentlySpawned.Enqueue(5);
        recentlySpawned.Enqueue(6);
        recentlySpawned.Enqueue(7);
    }

    public void Warp(float distance)
    {
        currentGoal -= distance;
        lastSpawnedZ -= distance;
    }
    void Update()
    {
        if (!active) return;
        if (currentGoal <= this.transform.position.x)
        {
            if (spawnInRow == 0)
            {
                ZOffset = Random.Range(-maxZOffset, maxZOffset);
                while (recentlySpawned.Contains(nextSpawn))
                {
                    nextSpawn = Random.Range(0, obstacles.Count);
                }
            }
            else
            {
                ZOffset = Random.Range(-overrideZOffset, overrideZOffset);
            }
            recentlySpawned.Enqueue(nextSpawn);
            if (Mathf.Abs(lastSpawnedZ - this.transform.position.z) > 180)
            {
                lastSpawnedZ = this.transform.position.z;
                Debug.Log("bind");
            }
            Vector3 randomPosition = new Vector3(transform.position.x + XOffset, YOffset, lastSpawnedZ + ZOffset);
            GameObject obj = Instantiate(obstacles[nextSpawn], randomPosition, Quaternion.identity);
            randomPosition.z += 180;
            Instantiate(obstacles[nextSpawn], randomPosition, Quaternion.identity);
            randomPosition.z -= 360;
            Instantiate(obstacles[nextSpawn], randomPosition, Quaternion.identity);
            lastSpawnedZ += ZOffset;
            currentGoal += (obj.GetComponent<Obstacle>().size * difficultyModifier);
            if (spawnInRow == 0)
            {
                spawnInRow = obj.GetComponent<Obstacle>().spawnInRow;
                if (spawnInRow != 0)
                {
                    overrideZOffset = obj.GetComponent<Obstacle>().overrideZAxis;
                    return;
                }
            }
            else
            {
                spawnInRow--;
                if (spawnInRow == 0)
                {
                    nextSpawn = 0;
                }
            }
            recentlySpawned.Dequeue();
        }
    }
}
