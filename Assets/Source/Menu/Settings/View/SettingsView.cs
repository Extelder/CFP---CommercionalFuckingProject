using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsView : MonoBehaviour, ISettingsViewable
{
    [field: SerializeField] public SettingsDefaultUIConfig SettingsDefaultUIConfig { get; set; }
    [field: SerializeField] public Canvas SettingsCanvas { get; set; }
    [field: SerializeField] public Transform ParentOrigin { get; set; }
}
