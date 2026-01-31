using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "SettingsConfig", menuName = "Settings/SettingsConfig")]
public class SettingsConfig : ScriptableObject
{
    [field: SerializeField] public  KeyCode PressKey { get; private set; }

    [field: SerializeReference] [field: SerializeReferenceButton] [field: SerializeField]
    public SettingsChangeContainer[] SettingsChangeContainers { get; private set; }
}
