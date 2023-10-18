using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private int fireBallDmg = 50;
    [SerializeField] float fireBallSpeed = 20f;
    [SerializeField] private Rigidbody2D theRb;
    
    

    private void Start()
    {

        theRb.velocity = transform.right * fireBallSpeed;

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
            theEnemies.TakingDmg(fireBallDmg);
            Destroy(gameObject);
        }
    }
}
