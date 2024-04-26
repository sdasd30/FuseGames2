using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour
{
    public GameObject endscreen;
    public double bpm = 120.0f;
    public double dspTime;
    public double duration;

    public double startTick;
    double nextTick = 0.0F; // The next tick in dspTime
    double sampleRate = 0.0F;
    bool ticked = false;
    private NoteSpawner spawner;
    private AudioClip soundClip;

    bool spawning = true;

    float nextSceneTimer = 8f;

    void Start()
    {
        soundClip = GetComponent<AudioSource>().clip;
        startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        spawner = FindObjectOfType<NoteSpawner>();
        nextTick = startTick + (60.0 / bpm);
        duration = soundClip.length;
    }

    void LateUpdate()
    {
        if (!ticked && nextTick >= AudioSettings.dspTime)
        {
            ticked = true;
            BroadcastMessage("OnTick");
        }
        if (dspTime - startTick + 5 >= soundClip.length)
        {
            //Debug.Log("Done");
            spawning = false;
            nextSceneTimer -= Time.deltaTime;
            if (nextSceneTimer <= 0)
            {
                endscreen.SetActive(true);
            }
        }
    }

    // Just an example OnTick here
    void OnTick()
    {
        spawner.queueNote = spawning;
    }

    void FixedUpdate()
    {
        double timePerTick = 60.0f / bpm;
        dspTime = AudioSettings.dspTime;

        while (dspTime >= nextTick)
        {
            ticked = false;
            nextTick += timePerTick;
        }

    }
}