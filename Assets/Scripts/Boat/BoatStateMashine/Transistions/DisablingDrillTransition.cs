using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DisablingDrillState))]
public class DisablingDrillTransition : Transition
{
    private DisablingDrillState _currentState;

    private void Awake()
    {
        _currentState = GetComponent<DisablingDrillState>();
    }

    private void Update()
    {
        if (_currentState.IsFinished == true)
        {
            NeedTransit = true;
        }
    }
}
