using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopConfig", menuName = "Shop")]
public class ShopConfig : ScriptableObject
{
    [field: SerializeField] public float BuyCooldown { get; set; }
    [field: SerializeField] public int RecoursePrice { get; set; }
}
