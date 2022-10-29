using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillingState : State
{
    private void Update()
    {
        Boat.transform.position = Vector3.MoveTowards(Boat.transform.position, Boat.CurrentBlock.transform.position, Boat.Engine.DrillSpeed * Time.deltaTime);

        if (Boat.transform.position == Boat.CurrentBlock.transform.position)
        {
            if (Boat.PreviousBlock == null)
            {
                Boat.WorldArray.RemoveBlock(Boat.CurrentBlock.XArrayIndex, Boat.CurrentBlock.YArrayIndex);
                Boat.PreviousBlock = Boat.CurrentBlock;
            }
        }
    }
}
