using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrateBar : MonoBehaviour
{
    [SerializeField] private Crate _crate;
    [SerializeField] private Image _crateIcon;
    [SerializeField] private Sprite _normalIcon;
    [SerializeField] private Sprite _fullIcon;
    [SerializeField] private TextMeshProUGUI _crateBarText;
    [SerializeField] private WorldArray _world;

    private List<Block> _minerals = new List<Block>();
    private float _blinkTime;
    private float _blinkCooldown = 0.5f;

    public void AddMineral(Block mineral)
    {
        if (_minerals.Count < _crate.MaxValue)
        {
            _minerals.Add(mineral);
            UpdateBarText();
        }
    }

    private void OnEnable()
    {
        _world.BlockIsDrilled += AddMineral;
    }

    private void OnDisable()
    {
        _world.BlockIsDrilled -= AddMineral;
    }

    private void Start()
    {
        UpdateBarText();
    }

    private void Update()
    {
        if (_minerals.Count == _crate.MaxValue)
        {
            Blink();
        }
    }

    private void Blink()
    {
        _blinkTime -= Time.deltaTime;

        if (_blinkTime <= 0)
        {
            if (_crateIcon.sprite == _normalIcon)
            {
                _crateIcon.sprite = _fullIcon;
            }
            else
            {
                _crateIcon.sprite = _normalIcon;
            }
            _blinkTime = _blinkCooldown;
        }
    }

    private void UpdateBarText()
    {
        _crateBarText.text = _minerals.Count + "/" +_crate.MaxValue;
    }
}
