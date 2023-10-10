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


   public void SetMaxHealth(int maxHp)
   {
      slider.maxValue = maxHp;
      fill.color = gradient.Evaluate(1f);

   }
   public void SetHealth(int health, int maxHp)
   {
      slider.value = health;
      hpTexte.text = health + " / " + maxHp;
      fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}
