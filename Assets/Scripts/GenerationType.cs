using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenerationType : ScriptableObject
{
    public abstract Block[,] Generate(GeneratedObject objectGenerated, Block[,] worldArray);
}
