using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface IQueueActionCallable<T> where T : AbstractProduct
{
    public Action<T> UnitActionCallable { get; set; }
}
