using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {
    public GameObject startUI;
    public GameObject playingUI;
    public GameObject endUI;

    public GameObject recordButtonLeft;
    public GameObject recordButtonRight;

    public Slider playerLeftHP;
    public Slider playerRightHP;

    private void Start()
    {
        playerLeftHP.value = playerLeftHP.maxValue = GameManager.instance.initialHP;
        playerRightHP.value = playerRightHP.maxValue = GameManager.instance.initialHP;
    }

    public void UpdateHP(int value, Players who)
    {
        if (who == Players.Left)
        {
            playerLeftHP.value = value;
        }
        else
        {
            playerRightHP.value = value;
        }
    }
}
