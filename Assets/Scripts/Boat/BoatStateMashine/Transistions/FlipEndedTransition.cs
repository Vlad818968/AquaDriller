using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(FlipState))]
public class FlipEndedTransition : Transition
{
    private FlipState _currentState;

    private void Awake()
    {
        _currentState = GetComponent<FlipState>();
    }

    private void Update()
    {
        if(_currentState.IsFinished == true)
        {
            NeedTransit = true;
        }
    }
}
