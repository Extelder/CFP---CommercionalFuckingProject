using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCutDownConfig", menuName = "Player/CutDown")]
public class PlayerCutDownConfig : ScriptableObject, IPlayerCutDownSpeedUpgradable
{
    [field: SerializeField] public float CutDownSpeed { get; private set; }

    public ReactiveProperty<float> CurrentValue { get; set; } = new ReactiveProperty<float>();

    public void Upgrade(float value)
    {
        CurrentValue.Value = value;
        CutDownSpeed = CurrentValue.Value;
    }
}
