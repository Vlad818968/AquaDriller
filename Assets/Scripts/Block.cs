using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]private BlockType _type;

    private int _xArrayIndex, _yArrayIndex;

    public int XArrayIndex => _xArrayIndex;
    public int YArrayIndex => _yArrayIndex;
    public BlockType Type => _type;

    public void SetArrayIndex(int x, int y)
    {
        _xArrayIndex = x;
        _yArrayIndex = y;
    }

    public enum BlockType
    {
        Water,
        Ground,
        Mineral,
        Rock,
        Bedrock,
        Gaz
    }
}
