using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewCrate", menuName = "Detail/Crate", order = 51)]
public class Crate : ScriptableObject
{
    [SerializeField] private int _maxValue;

    public int MaxValue => _maxValue;
}
