using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitPurchasable
{
    public int NeededRecources { get; set; }
    public void Buy();
}
