using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIChangeInput<T> : MonoBehaviour where T : Selectable
{
    public abstract T InputProvider { get; set; }
    [field: SerializeField] public TextMeshProUGUI Text { get; private set; }
}
