using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISettingsViewable
{
    public SettingsDefaultUIConfig SettingsDefaultUIConfig { get; set; }
    public Canvas SettingsCanvas { get; set; }
    public Transform ParentOrigin { get; set; }
}
