using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerUnitCutDownInput : IUnitActionInput
{
    public GameObject Tree { get; set; }
}