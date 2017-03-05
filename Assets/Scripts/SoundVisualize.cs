using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVisualize : MonoBehaviour {
    private Slider slider;
    public bool isReactive
    {
        get
        {
            return _isReactive;
        }
        set
        {
            _isReactive = value;
        }
    }
    private bool _isReactive = false;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    /// <summary>
    /// display the volume of current microphone as a bar
    /// </summary>
    /// <param name="Volume">a float number in [0,1]</param>
	private void DisplayVolume(float volume)
    {
        slider.value = volume;
    }

    /// <summary>
    /// Update the height of the bar every frame based on the sound from microphone
    /// </summary>
    void Update()
    {
        if (isReactive)
        {
            DisplayVolume(SoundDetect.instance.currentVolume);
        }
    }
}
