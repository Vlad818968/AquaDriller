using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewEngine",menuName ="Detail/Engine",order =51)]
public class Engine : ScriptableObject
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _drillSpeed;

    public float MoveSpeed => _moveSpeed;
    public float DrillSpeed => _drillSpeed;
}
