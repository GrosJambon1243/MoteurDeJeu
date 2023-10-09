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
    private int currentHealt;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _skeleRigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        currentHealt = maxHealth;
    }

    

    private void FixedUpdate()
    {
        if (player != null)
        {
            direction = (player.transform.position - transform.position).normalized;

            _skeleRigidBody.velocity = direction * (moveSpeed * Time.fixedDeltaTime);

        }
    }

    public void TakingDmg(int dmg)
    {
        currentHealt -= dmg;
        
        //play hurt anim
        if (currentHealt <= 0)
        {
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
