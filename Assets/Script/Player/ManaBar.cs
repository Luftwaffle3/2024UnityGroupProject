using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMaxMana(int maxMana)
    {
        slider.maxValue = maxMana;
    }

    public void SetMana(int mana)
    {
        slider.value = mana;
        fill.fillAmount = (float)mana / slider.maxValue;
    }
}
