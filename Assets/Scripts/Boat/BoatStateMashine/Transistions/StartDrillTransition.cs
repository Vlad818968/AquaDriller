using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDrillTransition : Transition
{
    private void Update()
    {
        Transit();
    }

    private void Transit()
    {
        if (Boat.transform.position != Boat.CurrentBlock.transform.position)
        {
            if (Boat.MoveState == Boat.State.Drilling)
            {
                NeedTransit = true;
            }
        }
    }
}
