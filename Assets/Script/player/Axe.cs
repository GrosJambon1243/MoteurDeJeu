using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private int axeDmg = 100;
    [SerializeField] float axeSpeed = 20f;
    [SerializeField] private Rigidbody2D theRb;
    private void Start()
    {

        theRb.velocity = Vector2.up * axeSpeed;

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var theEnemies = hitInfo.GetComponent<enemyDamage>();

        if (theEnemies != null)
        {
            theEnemies.TakingDmg(axeDmg);
            Destroy(gameObject);
        }
    }
}
