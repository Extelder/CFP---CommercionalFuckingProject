using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractFactory<T> : MonoBehaviour   where T : AbstactProduct
{
    public abstract T SpawnProduct { get; set; }
    public abstract T CreateProduct();
}
