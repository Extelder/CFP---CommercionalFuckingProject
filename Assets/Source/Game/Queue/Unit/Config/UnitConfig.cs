using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Unit")]
public class UnitConfig : ScriptableObject
{
    [field: SerializeField] public ReactiveProperty<float> Speed { get; private set; } = new ReactiveProperty<float>();
    [field: SerializeField] public uint NeededRecources { get; private set; }
}
