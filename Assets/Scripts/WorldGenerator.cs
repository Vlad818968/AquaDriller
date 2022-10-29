using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WorldGenerator : MonoBehaviour
{
    [SerializeField] Block _water;
    [SerializeField] int _worldHeight;
    [SerializeField] List<GeneratedObject> _worldObjects = new List<GeneratedObject>();
    [SerializeField] private WorldArray _worldArray;

    private int _worldWidth = 32;

    public event UnityAction<int, int> SetWorldSize;
    public event UnityAction Generated;

    private void Awake()
    {
        
        SetWorldSize.Invoke(_worldWidth, _worldHeight);
    }

    private void Start()
    {
        FillWithWater();
        StartGeneration();
    }

    private void FillWithWater()
    {
        Block[,] world = _worldArray.GetWorld();

        for (int x = 0; x < world.GetLength(0); x++)
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                world[x, y] = _water;
            }
        }

        _worldArray.SetWorld(world);
    }

    private void StartGeneration()
    {
        foreach (GeneratedObject generatedObject in _worldObjects)
        {
            Block[,] world = _worldArray.GetWorld();
           _worldArray.SetWorld(generatedObject.GenerationType.Generate(generatedObject, world));
        }

        Generated.Invoke();
    }

}

[System.Serializable]
public struct GeneratedObject
{
    [SerializeField] private Block _object;
    [SerializeField] private int _initialDepth;
    [SerializeField] private int _finishDepth;
    [SerializeField, Range(0, 100)] int _density;
    [SerializeField] GenerationType _generationType;

    public Block Object => _object;
    public int InitialDepth => _initialDepth;
    public int FinishDepth => _finishDepth;
    public int density => _density;
    public GenerationType GenerationType => _generationType;
}
