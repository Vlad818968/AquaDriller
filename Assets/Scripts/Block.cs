using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int _xArrayIndex, _yArrayIndex;

    public int XArrayIndex => _xArrayIndex;
    public int YArrayIndex => _yArrayIndex;

    public void SetArrayIndex(int x,int y)
    {
        _xArrayIndex = x;
        _yArrayIndex = y;
    }
}
