using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipState : State
{
    private Animator _animator;
    private Coroutine _flipCoroutine;
    private bool _isFinished;

    public bool IsFinished => _isFinished;
    void Start()
    {
        _animator = Boat.GetComponent<Animator>();
        _isFinished = false;
        StartFlip();
    }

    private void OnEnable()
    {
        if (_animator == null)
            return;

        _isFinished = false;
        StartFlip();
    }

    private void StartFlip()
    {
        if (_flipCoroutine != null)
        {
            StopCoroutine(_flipCoroutine);
        }

        _flipCoroutine = StartCoroutine(Flip());
    }

    private IEnumerator Flip()
    {
        _animator.Play("StartFlip");
        yield return new WaitForEndOfFrame();
        float animationLenght = _animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLenght);
        _animator.Play("EndFlip");
        Boat.transform.localScale = new Vector3(Boat.transform.localScale.x * -1, Boat.transform.localScale.y, Boat.transform.localScale.z);
        yield return new WaitForEndOfFrame();
        animationLenght = _animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLenght);
        Boat.IsFacingRight = !Boat.IsFacingRight;
        _animator.Play("Idle");
        _isFinished = true;
    }
}
