using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewEngine", menuName = "Detail/Drill", order = 51)]
public class Drill : ScriptableObject
{
    [SerializeField] private float _prepairSpeed;
    [SerializeField] private bool _isContinuousDrilling;
    [SerializeField] private bool _canDrillGas;
    public float PrepairSpeed => _prepairSpeed;
    public bool IsContinuousDrilling => _isContinuousDrilling;
    public bool CanDrillGas => _canDrillGas;
}
