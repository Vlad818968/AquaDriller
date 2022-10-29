using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablingDrillState : State
{
    private Animator _animator;
    private Coroutine _RaiseDrill;
    private bool _isFinished;

    public bool IsFinished => _isFinished;

    void Start()
    {
        _animator = Boat.GetComponent<Animator>();
        _isFinished = false;
        CheckDirection();
    }

    private void OnEnable()
    {
        if (_animator == null)
            return;

        _isFinished = false;
        CheckDirection();
    }

    private void CheckDirection()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("DrillingHorizontal"))
        {
            StartDisablingDrill("DisableDrillHorizontal");
        }
        else
        {
            StartDisablingDrill("DisableDrillVertical");
        }
    }

    private void StartDisablingDrill(string RaiseAnimation)
    {
        if (_RaiseDrill != null)
        {
            StopCoroutine(_RaiseDrill);
        }

        _RaiseDrill = StartCoroutine(DisablingDrill(RaiseAnimation));
    }

    private IEnumerator DisablingDrill(string RaiseAnimation)
    {
        _animator.Play(RaiseAnimation);
        _animator.SetFloat("PrepairSpeed", Boat.Drill.PrepairSpeed);
        yield return new WaitForEndOfFrame();
        float animationLenght = _animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLenght);
        _animator.Play("Idle");
        _isFinished = true;
    }
}
