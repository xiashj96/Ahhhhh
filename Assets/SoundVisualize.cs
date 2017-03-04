using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisualize : MonoBehaviour {

    public Color volumeColor;
    private float height;

    void Awake()
    {
        height = transform.localScale.y;
    }

    /// <summary>
    /// display the volume of current microphone as a bar
    /// </summary>
    /// <param name="Volume">a float number in [0,1]</param>
	public void DisplayVolume(float volume)
    {
        transform.localScale = new Vector3(transform.localScale.x, volume * height, transform.localScale.z);
    }
}
