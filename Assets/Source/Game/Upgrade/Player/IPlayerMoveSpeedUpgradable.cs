using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMoveSpeedUpgradable
{
    public float CurrentValue { get; set; }

    public void Upgrade(float newValue);
}