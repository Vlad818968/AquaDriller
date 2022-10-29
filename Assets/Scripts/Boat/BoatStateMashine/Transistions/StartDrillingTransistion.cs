using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RaiseDrillState))]
public class StartDrillingTransistion : Transition
{
    private RaiseDrillState _currentState;

    private void Awake()
    {
        _currentState = GetComponent<RaiseDrillState>();
    }

    private void Update()
    {
        if (_currentState.IsFinished == true)
        {
            NeedTransit = true;
        }
    }
}
