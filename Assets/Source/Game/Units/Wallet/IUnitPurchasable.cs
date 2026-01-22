using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitPurchasable
{
    public uint NeededRecources { get; set; }
    public void Buy();
}
