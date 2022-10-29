using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlipTransition : Transition
{
    private void Start()
    {
        Boat.Fliping += Transit;
    }

    private void OnDestroy()
    {
        Boat.Fliping -= Transit;
    }

    void Transit()
    {
        NeedTransit = true;
    }
}
