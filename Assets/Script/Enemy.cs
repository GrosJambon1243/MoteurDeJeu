using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D _skeleRigidBody;
    private BoxCollider2D _boxCollider2D;
    private Vector3 direction;
    [SerializeField]float moveSpeed;
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _skeleRigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            _spriteRenderer.flipX = false;
        }
        else if(direction.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void TakingDmg(int dmg)
    {
        currentHealth -= dmg;
        
        animator.SetTrigger("isHurt");
        if (currentHealth <= 0)
        {
            animator.SetTrigger("isHurt");
            SkeletonDeath();
        }
    }

    void SkeletonDeath()
    {
        _boxCollider2D.enabled = false;
        this.enabled = false;
        Destroy(gameObject,0);
    }
}
