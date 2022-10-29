using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private Animator _animator;

    private void Start()
    {
        _animator = Boat.GetComponent<Animator>();
        _animator.Play("Idle");
    }

    private void OnEnable()
    {
        if(_animator==null)
            return;

        _animator.Play("Idle");
    }
}
