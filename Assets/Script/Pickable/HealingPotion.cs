using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    [SerializeField] private int healingAmount;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var thePlayer = hitInfo.GetComponent<PlayerMovement>();

        if (thePlayer != null)
        {
            thePlayer.GetComponent<PlayerMovement>().HealingPlayer(healingAmount);
            Destroy(gameObject);
        }
    }
}
