using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldGenerator))]
public class WorldArray : MonoBehaviour
{
    private Block[,] _world;

    private WorldGenerator _generator;

    public Block CheckPosition(int x,int y)
    {
        x = Mathf.Clamp(x, 0, _world.GetLength(0) - 1);
        y = Mathf.Clamp(y,0,_world.GetLength(1)-1);
        return _world[x,y];
    }

    public Block[,] GetWorld()
    {
        return _world;
    }

    public void SetWorld(Block[,] world)
    {
        _world = world;
    }

    private void Awake()
    {
        _generator = GetComponent<WorldGenerator>();
        _generator.SetWorldSize += SetWorldSize;
    }

    private void Start()
    {
        _generator.SetWorldSize -= SetWorldSize;
    }

    private void SetWorldSize(int width, int height)
    {
        _world = new Block[width, height];
    }
}
