using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SettingsDefaultUIConfig", menuName = "Settings/SettingsDefaultUIConfig")]
public class SettingsDefaultUIConfig : ScriptableObject
{
    [field: SerializeField] public GameObject DefaultBoolPrefab;
    [field: SerializeField] public GameObject DefaultSliderPrefab;
}
