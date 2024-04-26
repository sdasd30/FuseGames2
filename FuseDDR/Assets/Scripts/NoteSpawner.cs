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

    public void Beat()
    {
        // Generate a random value between 0 and the sum of weights
        float totalWeight = restWeight + noteWeight + doubleWeight;
        float randomValue = randomizer.GetRandom() * totalWeight;
        Debug.Log(randomValue);

        // Determine which type of note to spawn based on the random value
        if (randomValue < restWeight)
        {
            Debug.Log("rest");
            // Spawn a rest
        }
        else if (randomValue < restWeight + noteWeight)
        {
            Debug.Log("single");
            // Spawn a single note
            Instantiate(notes[randomizer.RandomRange(0, notes.Count)], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("double");
            // Spawn a double note
            Instantiate(doubles[randomizer.RandomRange(0,doubles.Count)], transform.position, Quaternion.identity);
        }
    }
}