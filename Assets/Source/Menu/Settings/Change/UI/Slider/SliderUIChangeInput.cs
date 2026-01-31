using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUIChangeInput : UIChangeInput<Slider>
{
    [field: SerializeField] public override Slider InputProvider { get; set; }

    public void ChangeName(string name)
    {
        Text.text = name;
    }
}
