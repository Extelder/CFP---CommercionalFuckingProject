using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitActionProvider
{
    public void Provide(IPlayerUnitCutDownInput playerUnitCutDownInput);
}