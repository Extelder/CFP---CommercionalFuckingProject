using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }
}