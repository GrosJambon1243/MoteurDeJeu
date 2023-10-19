using TMPro;
using UnityEngine;

public class CurrencyBar : MonoBehaviour
{
    public TMP_Text currencyText;
    public void SetCurrency(float currency)
    {
        currencyText.text = $"x{currency}";
    }
}
