using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public bool queueNote;
    public List<GameObject> notes;
    public List<GameObject> doubles;
    public float restWeight;
    public float noteWeight;
    public float doubleWeight;

    private Randomizer randomizer;

    private void Start()
    {
        randomizer = FindObjectOfType<Randomizer>();
    }

    private void Update()
    {
        if (queueNote)
        {
            Beat();
            queueNote = false;
        }
    }

    public void Beat(float rest = 0, float note = 0, float doublenote = 0)
    {
        if (rest != 0)
        {
            restWeight = rest;
        }
        if (note != 0)
        {
            noteWeight = note;
        }
        if (doublenote != 0)
        {
            doubleWeight = 0;
        }
        // Generate a random value between 0 and the sum of weights
        float totalWeight = restWeight + noteWeight + doubleWeight;
        float randomValue = (randomizer.GetRandom() / 255f) * totalWeight;

        // Determine which type of note to spawn based on the random value
        if (randomValue < restWeight)
        {
            // Spawn a rest
            Debug.Log("Rest spawned.");
        }
        else if (randomValue < restWeight + noteWeight)
        {
            // Spawn a single note
            randomValue = randomizer.GetRandom();
            int index = (int) Mathf.Lerp(0, notes.Count, randomValue / 255);
            Instantiate(notes[index], transform.position, Quaternion.identity);
            Debug.Log("Single note spawned.");
        }
        else
        {
            // Spawn a double note
            int index = (int)Mathf.Lerp(0, doubles.Count, randomValue / 255);
            Instantiate(doubles[index], transform.position, Quaternion.identity);
            Debug.Log("Double note spawned.");
        }
    }
}