using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    [SerializeField] private int healingAmount;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var thePlayer = hitInfo.GetComponent<playerMovement>();

        if (thePlayer != null)
        {
            thePlayer.GetComponent<playerMovement>().HealingPlayer(healingAmount);
            Destroy(gameObject);
        }
    }
}
