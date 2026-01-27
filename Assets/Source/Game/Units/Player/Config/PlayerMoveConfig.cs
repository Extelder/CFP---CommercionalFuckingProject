using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveConfig", menuName = "Player/Move")]
public class PlayerMoveConfig : ScriptableObject, IPlayerMoveSpeedUpgradable
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float RotateSpeed { get; private set; }
    public ReactiveProperty<float> CurrentValue { get; set; } = new ReactiveProperty<float>();

    public void Upgrade(float value)
    {
        CurrentValue.Value = value;
        MoveSpeed = CurrentValue.Value;
    }
}