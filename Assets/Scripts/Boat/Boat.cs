using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Animator))]
public class Boat : MonoBehaviour
{
    [HideInInspector] public bool IsFacingRight = false;

    [SerializeField] private DynamicJoystick Joystick;
    [SerializeField] private WorldArray _worldArray;
    [Header("BoatDetails")]
    [SerializeField] private Engine _engine;
    [SerializeField] private Drill _drill;

    private ArrayPosition _position;

    public event UnityAction Fliping;

    public Engine Engine => _engine;
    public Drill Drill => _drill;
    public WorldArray WorldArray => _worldArray;
    public Block CurrentBlock { get; private set; }
    public Block PreviousBlock { get; set; }
    public State MoveState { get; private set; }

    private void Start()
    {
        BoatInitialize();
    }

    private void Update()
    {
        if (Joystick.Horizontal <= -0.5f)
        {
            if (IsFacingRight == true)
            {
                Fliping?.Invoke();
            }
            else
            {
                if (BlockReached() == true)
                {
                    UpdateCurrentBlock(_position.X - 1, _position.Y);
                }
            }
        }

        if (Joystick.Horizontal >= 0.5f)
        {
            if (IsFacingRight == false)
            {
                Fliping?.Invoke();
            }
            else
            {
                if (BlockReached() == true)
                {
                    UpdateCurrentBlock(_position.X + 1, _position.Y);
                }
            }
        }

        if (Joystick.Vertical < -0.5f)
        {
            if (BlockReached() == true)
            {
                UpdateCurrentBlock(_position.X, _position.Y + 1);
            }
        }

        if (Joystick.Vertical > 0.5f)
        {
            if (BlockReached() == true)
            {
                UpdateCurrentBlock(_position.X, _position.Y - 1);
            }
        }

        if (PreviousBlock != null)
        {
            if (PreviousBlock != CurrentBlock)
            {
                Destroy(PreviousBlock.gameObject);
            }
        }
    }

    private bool BlockReached()
    {
        if (transform.position == CurrentBlock.transform.position)
        {
            _position.SetPosition(CurrentBlock.XArrayIndex, CurrentBlock.YArrayIndex);
            return true;
        }

        return false;
    }

    private void UpdateCurrentBlock(int x, int y)
    {
        Block block = _worldArray.CheckPosition(x, y);

        if (block != null)
        {
            SetState(block);
        }
    }

    private void SetState(Block block)
    {
        if (block.Type != Block.BlockType.Water)
        {
            if (block.transform.position.y > transform.position.y)
            {
                return;
            }
        }

        switch (block.Type)
        {
            case Block.BlockType.Water:
                CurrentBlock = block;
                MoveState = State.Move;
                break;
            case Block.BlockType.Mineral:
                CurrentBlock = block;
                MoveState = State.Drilling;
                break;
            case Block.BlockType.Ground:
                CurrentBlock = block;
                MoveState = State.Drilling;
                break;
            case Block.BlockType.Gaz:
                CurrentBlock = block;
                GazState();
                break;
        }
    }

    private void GazState()
    {
        if (_drill.CanDrillGas == true)
        {
            MoveState = State.Drilling;
        }
        else
        {
            MoveState = State.Move;
        }
    }

    private void BoatInitialize()
    {
        transform.position = new Vector2(1f, 0f);
        _position.SetPosition(17, 0);
        CurrentBlock = _worldArray.CheckPosition(_position.X, _position.Y);
    }

    public enum State
    {
        Move,
        Drilling
    }
}

public struct ArrayPosition
{
    [SerializeField] private int _xPosition;
    [SerializeField] private int _yPosition;

    public int X => _xPosition;
    public int Y => _yPosition;

    public void SetPosition(int x, int y)
    {
        _xPosition = x;
        _yPosition = y;
    }
}