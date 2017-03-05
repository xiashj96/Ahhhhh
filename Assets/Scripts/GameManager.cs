using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class GameManager : Singleton<GameManager> {

    // 双方初始血量
    public int initialHP = 10;

    public Player WangWang;
    public Player XianYu;

    [SerializeField]
    private GameObject SoundBarLeft;
    [SerializeField]
    private GameObject SoundBarRight;

    [SerializeField]
    private Wind wind;

    public float recordTime = 3f;
    public float waitTime = 3f;

    public void StartGame()
    {
        fsm.ChangeState(States.Left);
        WangWang.HP = initialHP;
        XianYu.HP = initialHP;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    public void CheckRoundEnd()
    {
        if (WangWang.HP <= 0 || XianYu.HP <= 0)
        {
            fsm.ChangeState(States.End);
        }
        else
        {
            if (fsm.State == States.Left)
            {
                fsm.ChangeState(States.Right);
            }
            else if (fsm.State == States.Right)
            {
                fsm.ChangeState(States.Left);
            }
        }
    }

    private void ChangeWindDirection()
    {
        float angle = Random.Range(0f, 360f);
        wind.SetWindDirection(angle);
    }

    public enum States
    {
        Init,
        Left,
        Right,
        End
    }
    StateMachine<States> fsm;

    void Start()
    {
        fsm = StateMachine<States>.Initialize(this);
        fsm.ChangeState(States.Init);
    }

    void Init_Exit()
    {
        UIManager.instance.startUI.SetActive(false);
        UIManager.instance.playingUI.SetActive(true);
    }

    void Left_Enter()
    {
        ChangeWindDirection();
        UIManager.instance.recordButtonLeft.SetActive(true);
        /*yield return new WaitForSeconds(prepareTime);
        SoundBarLeft.SetActive(true);
        yield return new WaitForSeconds(speakTime);
        float result = 0;
        for (int i = 0; i < 5; ++i)
        {
            result += SoundDetect.instance.currentVolume;
            yield return null;
        }
        result = result / 5;
        SoundBarLeft.SetActive(false);

        Throw.instance.ThrowStuff(result, Player.Left);

        yield return new WaitForSeconds(waitTime);
        if (playerLeftHP <= 0 || playerRightHP <= 0)
        {
            fsm.ChangeState(States.End);
        }
        else
        {
            fsm.ChangeState(States.Right);
        }*/
    }

    void Left_Exit()
    {
        UIManager.instance.recordButtonLeft.SetActive(false);
    }

    void Right_Enter()
    {
        ChangeWindDirection();
        UIManager.instance.recordButtonRight.SetActive(true);
        /*yield return new WaitForSeconds(prepareTime);
        SoundBarRight.SetActive(true);
        yield return new WaitForSeconds(speakTime);
        float result = 0;
        for (int i = 0; i < 5; ++i)
        {
            result += SoundDetect.instance.currentVolume;
            yield return null;
        }
        result = result / 5;
        SoundBarRight.SetActive(false);

        Throw.instance.ThrowStuff(result, Player.Right);

        yield return new WaitForSeconds(waitTime);
        if (playerLeftHP <= 0 || playerRightHP <= 0)
        {
            fsm.ChangeState(States.End);
        }
        else
        {
            fsm.ChangeState(States.Left);
        }*/
    }

    void Right_Exit()
    {
        UIManager.instance.recordButtonRight.SetActive(false);
    }

    void End_Enter()
    {
        UIManager.instance.playingUI.SetActive(false);
        UIManager.instance.endUI.SetActive(true);
    }
}
