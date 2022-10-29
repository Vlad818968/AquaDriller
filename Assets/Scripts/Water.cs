using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Block
{
    [SerializeField] private List<Sprite> _maskSprites;
    [SerializeField] private SpriteRenderer _mask;
    [SerializeField, Range(0, 100)] int _propsDensity;
    [SerializeField] private List<Props> _groundProps;
    [SerializeField] private List<Props> _wallProps;
    [SerializeField] private List<Props> _caveProps;
    private string _maskId = "";
    private WorldArray _worldArray;

    private void Start()
    {
        _worldArray = GetComponentInParent<WorldArray>();
        SetWaterMaskId();
    }

    public void SetWaterMaskId()
    {
        _maskId = "";
        _maskId += ReadGround(XArrayIndex - 1, YArrayIndex);
        _maskId += ReadGround(XArrayIndex, YArrayIndex - 1);
        _maskId += ReadGround(XArrayIndex + 1, YArrayIndex);
        _maskId += ReadGround(XArrayIndex, YArrayIndex + 1);
        WaterInitialise();
    }

    private int ReadGround(int xPosition, int yPosition)
    {
        Block obj = _worldArray.CheckPosition(xPosition, yPosition);

        if (obj == null)
        {
            return 0;
        }

        if (obj.TryGetComponent<Water>(out Water water))
        {
            return 0;
        }

        return 1;
    }

    private void WaterInitialise()
    {
        switch (_maskId)
        {
            case "0000":
                _mask.sprite = null;
                break;
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
                SpawnProps(_groundProps, _maskSprites[8]);
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
                SpawnProps(_caveProps, _maskSprites[12]);
                break;
            case "1010":
                SpawnProps(_wallProps, _maskSprites[13]);
                break;
            case "1111":
                _mask.sprite = _maskSprites[14];
                break;
        }
    }

    private void SpawnProps(List<Props> props, Sprite mask)
    {
        if (Random.Range(0, 100) <= _propsDensity)
        {
            Props item = Instantiate(props[Random.Range(0, props.Count)], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            item.transform.parent = transform;
        }
        else
        {
            _mask.sprite = mask;
        }
    }
}
