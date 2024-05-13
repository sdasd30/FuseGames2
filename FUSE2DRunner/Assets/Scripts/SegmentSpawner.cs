using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{
    public List<GameObject> segments;
    public void SpawnSegment()
    {
        Debug.Log("Spawning segment");
        // Instantiate a new segment
        GameObject newSegment = Instantiate(segments[Random.Range(0, segments.Count)], transform.position, Quaternion.identity);
    }
}
