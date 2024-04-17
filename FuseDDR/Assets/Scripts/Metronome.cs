using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour
{
    public double bpm = 120.0f;

    double nextTick = 0.0F; // The next tick in dspTime
    double sampleRate = 0.0F;
    bool ticked = false;
    private NoteSpawner spawner;
    private AudioSource soundSource;
    public AudioClip soundClip;

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        spawner = FindObjectOfType<NoteSpawner>();
        nextTick = startTick + (60.0 / bpm);
    }

    void LateUpdate()
    {
        if (!ticked && nextTick >= AudioSettings.dspTime)
        {
            ticked = true;
            BroadcastMessage("OnTick");
        }
    }

    // Just an example OnTick here
    void OnTick()
    {
        spawner.queueNote = true;
        soundSource.PlayOneShot(soundClip);
    }

    void FixedUpdate()
    {
        double timePerTick = 60.0f / bpm;
        double dspTime = AudioSettings.dspTime;

        while (dspTime >= nextTick)
        {
            ticked = false;
            nextTick += timePerTick;
        }

    }
}