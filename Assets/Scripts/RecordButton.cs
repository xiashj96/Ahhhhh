using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 开始录音按钮的功能
/// </summary>

public class RecordButton : MonoBehaviour {

    private GameObject recordingIndicator;
    public Player player;

    private void Awake()
    {
        recordingIndicator = transform.GetChild(0).gameObject;
    }

    public void OnButtonClicked()
    {
        StartCoroutine(StartRecording());
    }

    IEnumerator StartRecording()
    {
        recordingIndicator.SetActive(true);
        recordingIndicator.GetComponent<SoundVisualize>().isReactive = true;
        // start recording
        yield return new WaitForSeconds(GameManager.instance.recordTime);
        /*float result = 0;
        for (int i = 0; i < 5; ++i)
        {
            result += SoundDetect.instance.currentVolume;
            yield return null;
        }
        result = result / 5;*/
        recordingIndicator.GetComponent<SoundVisualize>().isReactive = false;
        float result = SoundDetect.instance.currentVolume; // stop recording

        player.ThrowStuff(result, (Stuffs)Random.Range(0, 4));

        yield return new WaitForSeconds(GameManager.instance.waitTime);
        GameManager.instance.CheckRoundEnd();
    }

    private void OnDisable()
    {
        recordingIndicator.SetActive(false);
    }

    
}
