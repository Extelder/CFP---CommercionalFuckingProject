using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsView : MonoBehaviour, ISettingsViewable
{
    [field: SerializeField] public Canvas SettingsCanvas { get; set; }
}
