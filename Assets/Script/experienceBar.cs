using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class experienceBar : MonoBehaviour
{
    public Slider slider;
    
    public Gradient gradient;
    public Image fill;

    public void SetMaxExperience(float maxExp)
    {
        slider.maxValue = maxExp;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetExperience(float experience)
    {
        slider.value = experience;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
