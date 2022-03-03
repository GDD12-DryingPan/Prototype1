using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(double health)
    {
        slider.maxValue = (float)health;
        slider.value = (float)health;
    }

    public void SetHealth(double health)
    {
        slider.value = (float)health;
    }
}
