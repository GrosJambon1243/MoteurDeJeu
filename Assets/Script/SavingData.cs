using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SavingData
{
   public float goldCoin;

   public SavingData(gameManager gameManager)
   {
      goldCoin = gameManager.totalCurrency;
   }
}
