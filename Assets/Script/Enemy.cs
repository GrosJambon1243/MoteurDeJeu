using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : enemyDamage
{
    private GameObject player;
    private Rigidbody2D _skeleRigidBody;
    private BoxCollider2D _boxCollider2D;
    private Vector3 direction;
    [SerializeField]float moveSpeed;
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
   
    [SerializeField] GameObject currency, experience;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _skeleRigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        
        currentHealth = maxHealth;
    }

    

    private void FixedUpdate()
    {
        if (player != null)
        {
            direction = (player.transform.position - transform.position).normalized;

            _skeleRigidBody.velocity = direction * (moveSpeed * Time.fixedDeltaTime);
            animator.SetInteger("isWalking",1);

        }

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if(direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    public override void TakingDmg(int dmg)
    {
        currentHealth -= dmg;
        
        animator.SetTrigger("isHurt");
        if (currentHealth <= 0)
        {
            animator.SetTrigger("isHurt");
            DeathAnim(currency,experience);
        }
    }


    public override void DeathAnim(GameObject coin, GameObject expCrystal)
    {
        Instantiate(experience);
        _boxCollider2D.enabled = false;
        this.enabled = false;
        Destroy(gameObject,0);
    }

  
}
