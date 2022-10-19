using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Block
{
    [SerializeField] private List<Sprite> _maskSprites;
    [SerializeField] private SpriteRenderer _mask;

    private string _maskId = "";
    private WorldArray _worldArray;

    private void Start()
    {
        _worldArray = GetComponentInParent<WorldArray>();
        SetWaterMaskId();
        WaterInitialise();
    }

    private void SetWaterMaskId()
    {
        _maskId += ReadGround(XArrayIndex-1,YArrayIndex);
        _maskId += ReadGround(XArrayIndex, YArrayIndex-1);
        _maskId += ReadGround(XArrayIndex + 1, YArrayIndex);
        _maskId += ReadGround(XArrayIndex, YArrayIndex+1);
        
    }

    private int ReadGround(int xPosition,int yPosition)
    {
        Block obj = _worldArray.CheckPosition(xPosition,yPosition);
        
        if(obj.TryGetComponent<Water>(out Water water))
        {
            return 0;
        }

        return 1;
    }

    private void WaterInitialise()
    {
        switch (_maskId)
        {
            case "1011":
                _mask.sprite = _maskSprites[0];
                break;
            case "1101":
                _mask.sprite = _maskSprites[1];
                break;
            case "1110":
                _mask.sprite = _maskSprites[2];
                break;
            case "0111":
                _mask.sprite = _maskSprites[3];
                break;
            case "1100":
                _mask.sprite = _maskSprites[4];
                break;
            case "0110":
                _mask.sprite = _maskSprites[5];
                break;
            case "1001":
                _mask.sprite = _maskSprites[6];
                break;
            case "0011":
                _mask.sprite = _maskSprites[7];
                break;
            case "0001":
                _mask.sprite = _maskSprites[8];
                break;
            case "1000":
                _mask.sprite = _maskSprites[9];
                break;
            case "0100":
                _mask.sprite = _maskSprites[10];
                break;
            case "0010":
                _mask.sprite = _maskSprites[11];
                break;
            case "0101":
                _mask.sprite = _maskSprites[12];
                break;
            case "1010":
                _mask.sprite = _maskSprites[13];
                break;
            case "1111":
                _mask.sprite = _maskSprites[14];
                break;
        }
    }
}
