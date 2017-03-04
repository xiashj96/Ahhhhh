using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetect : MonoBehaviour {
    private AudioClip clip;
    private string deviceName;
    public int sampleSize = 128;
    public float maxVolume;
    public SoundVisualize sv;
    private float sum_old = 0;
	// Use this for initialization
	void Start () {
        deviceName = Microphone.devices[0];
        Debug.LogFormat("Number of devices: {0}", Microphone.devices.Length);
        clip = Microphone.Start(deviceName, true, 10, 44100);
	}
	
	// Update is called once per frame
	void Update () {
        int startPos = Microphone.GetPosition(deviceName) - (sampleSize + 1);
        float[] data = new float[sampleSize];
        clip.GetData(data, Mathf.Max(0,startPos));

        float sum = 0f;
        foreach (float sample in data)
        {
            sum += Mathf.Abs(sample);
        }
        // 平滑音量信号
        float volume = Mathf.Lerp(sum_old, sum, 0.2f);
        sum_old = volume;

        sv.DisplayVolume(Mathf.Clamp(volume, 0, maxVolume) / maxVolume);
	}
}
