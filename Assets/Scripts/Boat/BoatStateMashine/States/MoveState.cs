using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private void Update()
    {
        if (Boat.CurrentBlock != null)
        {
            Boat.transform.position = Vector3.MoveTowards(Boat.transform.position, Boat.CurrentBlock.transform.position, Boat.Engine.MoveSpeed * Time.deltaTime);
        }

    }
}
