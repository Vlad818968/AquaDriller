using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDrillingTransition : Transition
{
    private float _moveTime;
    private float _moveCooldown = 0.1f;
    private void Update()
    {
        if (Boat.MoveState!=Boat.State.Drilling)
        {
            NeedTransit = true;
        }

        if (Boat.transform.position == Boat.CurrentBlock.transform.position)
        {
            if (Boat.Drill.IsContinuousDrilling == false)
            {
                NeedTransit = true;
            }

            _moveTime -= Time.deltaTime;

            if (_moveTime <= 0)
            {
                NeedTransit = true;
            }
        }
        else
        {
            _moveTime = _moveCooldown;
        }

    }
}
