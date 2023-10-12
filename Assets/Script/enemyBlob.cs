using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBlob : enemyDamage
{
    private GameObject player;
    private Rigidbody2D _blobRigidBody;
    private BoxCollider2D _blobBoxCollider2D;
    private Vector3 direction;
    [SerializeField]float moveSpeed,range;
    public int blobMaxHealth = 100;
    private int blobCurrentHealth;
    public Animator animator;
    
    public Transform firePoint;
    [SerializeField] GameObject bullet,currency,experience;
   
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _blobRigidBody = GetComponent<Rigidbody2D>();
        _blobBoxCollider2D = GetComponent<BoxCollider2D>();
       
        blobCurrentHealth = blobMaxHealth;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            direction = (player.transform.position - transform.position).normalized;

            _blobRigidBody.velocity = direction * (moveSpeed * Time.fixedDeltaTime);
            animator.SetInteger("blobWalking",1);

        }

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if(direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }

        if (Input.GetKey(KeyCode.C))
        {
            ShootBullet();
        }
        
    }

    public override void TakingDmg(int dmg)
    {
        blobCurrentHealth -= dmg;
        if (blobCurrentHealth <= 0)
        {
            DeathAnim(currency,experience);
        }
    }

    public void ShootBullet()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public override void DeathAnim(GameObject coin, GameObject expCrystal)
    {
        Instantiate(experience);
        _blobBoxCollider2D.enabled = false;
        this.enabled = false;
        Destroy(gameObject,0);
    }
}
