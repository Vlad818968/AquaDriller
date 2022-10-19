using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(WorldArray))]
[RequireComponent(typeof(WorldGenerator))]
public class WorldRenderer : MonoBehaviour
{
    private WorldArray _worldArray;
    private WorldGenerator _generator;

    private void Awake()
    {
        _worldArray = GetComponent<WorldArray>();
        _generator = GetComponent<WorldGenerator>();
        _generator.Generated += StartRender;
    }

    private void StartRender()
    {
        Block[,] world = _worldArray.GetWorld();

        for (int x = 0; x < world.GetLength(0); x++)
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                Block obj = Instantiate(world[x, y],transform);
                obj.SetArrayIndex(x,y);
                obj.transform.localPosition = new Vector3(x,-y);
                world[x, y] = obj;
                
            }
        }

        _worldArray.SetWorld(world);
        _generator.Generated -= StartRender;
    }
}
