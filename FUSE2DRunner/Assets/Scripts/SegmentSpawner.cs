using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{
    public Object[] segments;

    private void Start()
    {
        segments = Resources.LoadAll("SegmentPrefabs", typeof(GameObject));
        Debug.Log(segments);
    }
    public void SpawnSegment()
    {

        Debug.Log("Spawning segment");
        // Instantiate a new segment
        GameObject newSegment = Instantiate((GameObject) segments[Random.Range(0, segments.Length)], transform.position, Quaternion.identity);
    }
}
