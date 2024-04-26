using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurationSlider : MonoBehaviour
{
    private Metronome songplayer;
    private double duration;
    private Slider slider;
    private AudioSource soundsource;

    private float percentage;
    // Start is called before the first frame update
    void Start()
    {
        songplayer = FindObjectOfType<Metronome>();
        slider = GetComponent<Slider>();
        soundsource = songplayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Time: " + (songplayer.dspTime - songplayer.startTick) + " Dur: " + soundsource.clip.length);
        slider.value = (float) ((songplayer.dspTime - songplayer.startTick) / soundsource.clip.length);
    }
}
