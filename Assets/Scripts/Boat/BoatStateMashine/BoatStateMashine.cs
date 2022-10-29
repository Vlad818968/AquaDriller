using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Boat))]
public class BoatStateMashine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Boat _boat;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        _boat = GetComponent<Boat>();
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_boat);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_boat);
    }
}
