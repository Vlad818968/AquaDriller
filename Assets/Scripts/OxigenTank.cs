using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewTank", menuName = "Detail/OxigenTank", order = 51)]
public class OxigenTank : ScriptableObject
{
    [SerializeField] float _oxigen;

    public float Oxigen => _oxigen;
}
