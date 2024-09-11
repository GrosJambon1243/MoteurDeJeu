using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class FireBall : MonoBehaviour, IWeaponLevelUp
{
     private float fireBallDmg;
     float fireBallSpeed;
    [SerializeField] private Rigidbody2D theRb;
   
    private void Start()
    {

        fireBallDmg = 25f;
        fireBallSpeed = 20f;
        gameObject.transform.localScale = new Vector3(2f, 2f, 0f);
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

    public void LevelUp(float Damage, float Speed, int ScaleModifier)
    {
        fireBallDmg *= Damage;
        fireBallSpeed *= Speed;
        gameObject.transform.localScale *= ScaleModifier;
    }
}
