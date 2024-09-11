using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthBar : MonoBehaviour
{
   public Slider slider;
   public TMP_Text hpTexte;
   public Gradient gradient;
   public Image fill;


   public void SetMaxHealth(float maxHp)
   {
      slider.maxValue = maxHp;
      fill.color = gradient.Evaluate(1f);

   }
   public void SetHealth(float health, float maxHp)
   {
      slider.value = health;
      hpTexte.text = health + " / " + maxHp;
      fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}
