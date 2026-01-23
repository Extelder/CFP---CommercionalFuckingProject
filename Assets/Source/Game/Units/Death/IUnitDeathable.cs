using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitDeathable
{
    public void Death();
    public bool CanDie { get; set; }
}
