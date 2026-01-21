using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractFactory<T> where T : AbstractProduct
{
    public abstract T SpawnProduct { get; set; }
    public abstract T CreateProduct(Vector3 spawnPoint);
}
