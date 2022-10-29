using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class OxigenBar : MonoBehaviour
{
    [SerializeField] private OxigenTank _oxigenTank;
    [SerializeField] private Boat _player;
    [SerializeField] private Image _barImage;
    [SerializeField, Range(5, 90)] private float _criticalPercentage = 30;

    private Slider _oxigenBar;
    private float _oxigenValue;
    private float _blinkTime;
    private float _blinkCooldown=0.5f;
    private float _criticalValue;

    private void Start()
    {
        _oxigenBar = GetComponent<Slider>();
        FillUpOxygen();
    }

    private void Update()
    {
        if (_player.transform.position.y < 0)
        {
            _oxigenValue -= Time.deltaTime;
            _oxigenBar.value = _oxigenValue;
        }

        if (_oxigenValue <= _criticalValue)
        {
            Blink();
        }
    }

    private void FillUpOxygen()
    {
        _barImage.color = new Color32(15, 131, 234, 255);
        _oxigenValue = _oxigenTank.Oxigen;
        _oxigenBar.maxValue = _oxigenValue;
        _oxigenBar.value = _oxigenBar.maxValue;
        _criticalValue = (_oxigenBar.maxValue / 100) * _criticalPercentage;
    }

    private void Blink()
    {
        _blinkTime -= Time.deltaTime;

        if (_blinkTime <= 0)
        {
            if (_barImage.color == Color.white)
            {
                _barImage.color = new Color32(15, 131, 234, 255);
            }
            else
            {
                _barImage.color = Color.white;
            }
            _blinkTime = _blinkCooldown;
        }
    }
}
