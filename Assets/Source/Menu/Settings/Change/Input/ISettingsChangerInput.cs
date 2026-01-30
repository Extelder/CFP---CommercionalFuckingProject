using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISettingsChangerInput<T>
{
    public Action<T> ValueChanged { get; set; }
}
