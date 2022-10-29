using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Boat Boat { get; private set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(Boat boat)
    {
        Boat = boat;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
