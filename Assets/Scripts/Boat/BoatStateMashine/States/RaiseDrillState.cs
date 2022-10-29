using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseDrillState : State
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
        if (Boat.transform.position.y > Boat.CurrentBlock.transform.position.y)
        {
            StartRaiseDrill("RaiseDrillVertical", "DrillingVertical");
        }
        else
        {
            StartRaiseDrill("RaiseDrillHorizontal", "DrillingHorizontal");
        }
    }

    private void StartRaiseDrill(string RaiseAnimation, string DrillingAnimation)
    {
        if (_RaiseDrill != null)
        {
            StopCoroutine(_RaiseDrill);
        }

        _RaiseDrill = StartCoroutine(RaiseDrill(RaiseAnimation,DrillingAnimation));
    }

    private IEnumerator RaiseDrill(string RaiseAnimation,string DrillingAnimation)
    {
        _animator.Play(RaiseAnimation);
        _animator.SetFloat("PrepairSpeed", Boat.Drill.PrepairSpeed);
        yield return new WaitForEndOfFrame();
        float animationLenght = _animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLenght);
        _animator.Play(DrillingAnimation);
        _isFinished = true;
    }
}
