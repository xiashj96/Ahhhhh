using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class GameManager : MonoBehaviour {

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


}
