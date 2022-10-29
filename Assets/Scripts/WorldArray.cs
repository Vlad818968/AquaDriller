using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WorldGenerator))]
public class WorldArray : MonoBehaviour
{
    public event UnityAction<Block> BlockIsDrilled;

    [SerializeField] Block _water;

    private Block[,] _world;
    private WorldGenerator _generator;
    private Block _deletedBlock;

    public float GetDeepWorld()
    {
        return _world.GetLength(1);
    }

    public void RemoveBlock(int x, int y)
    {
        Block block = _world[x, y];
        block.gameObject.SetActive(false);
        //Destroy(_world[x, y].gameObject,3);
        _world[x, y] = _water;
        Block obj = Instantiate(_world[x, y], transform);
        obj.SetArrayIndex(x, y);
        obj.transform.localPosition = new Vector3(x, -y);
        _world[x, y] = obj;
        ResetWater(x - 1, y);
        ResetWater(x + 1, y);
        ResetWater(x, y - 1);
        ResetWater(x, y + 1);

        if (block.Type == Block.BlockType.Mineral|| block.Type == Block.BlockType.Gaz)
        {
            BlockIsDrilled?.Invoke(block);
        }
    }

    public Block CheckPosition(int x, int y)
    {
        if (x < 0 || x > _world.GetLength(0) - 1)
        {
            return null;
        }

        if (y < 0 || y > _world.GetLength(1) - 1)
        {
            return null;
        }

        return _world[x, y];
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
        transform.position = new Vector2(-_world.GetLength(0) / 2, 0);
    }

    private void SetWorldSize(int width, int height)
    {
        _world = new Block[width, height];
    }

    private void ResetWater(int x, int y)
    {
        Block block = CheckPosition(x, y);

        if (block != null)
        {
            if (block.TryGetComponent<Water>(out Water water))
            {
                Destroy(_world[x, y].gameObject);
                _world[x, y] = _water;
                Block obj = Instantiate(_world[x, y], transform);
                obj.SetArrayIndex(x, y);
                obj.transform.localPosition = new Vector3(x, -y);
                _world[x, y] = obj;
            }
        }
    }
}
