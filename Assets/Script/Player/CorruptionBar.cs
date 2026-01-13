using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorruptionBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMaxCorruption(float maxCorruption)
    {
        slider.maxValue = maxCorruption;
        slider.value = 0; // Start at 0

    }

    public void SetCorruption(int corruption)
    {
        slider.value = corruption;
    }
}