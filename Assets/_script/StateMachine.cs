using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        menu,
        playing,
        resetPosition,
        endGame
    }

    public Dictionary<States, StateBase> DictionaryState;

    private StateBase _currentState;
    public Player player;
    public float timeToStartGame = 1f;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;
        DictionaryState = new Dictionary<States, StateBase>();
        DictionaryState.Add(States.menu, new StateBase());
        DictionaryState.Add(States.playing, new StatePlaying());
        DictionaryState.Add(States.resetPosition, new StateResetPosition());
        DictionaryState.Add(States.endGame, new StateEndGame());
        SwitchStates(States.menu);
    }

    private void StartGame()
    {
        SwitchStates(States.menu);
    }

    public void SwitchStates(States state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = DictionaryState[state];

        if (_currentState != null) _currentState.OnStateEnter(player);
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();

    }

    public void ResetPosition()
    {
        SwitchStates(States.resetPosition);
    }
}