using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Unit")]
public class UnitConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public uint NeededRecources { get; private set; }
}
