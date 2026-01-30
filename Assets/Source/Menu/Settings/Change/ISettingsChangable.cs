using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISettingsChangable<T>
{
    public T CurrentValue { get; set; }
    public void Change(T value);
}
