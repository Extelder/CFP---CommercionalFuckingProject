using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface IQueueKillable<T> where T : AbstractProduct
{
    public Action<T> UnitCanBeKilled { get; set; }
}
