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
    [SerializeField]float moveSpeed;
    public int blobMaxHealth = 100;
    private int blobCurrentHealth;
    public Animator animator;
    private SpriteRenderer _spriteRenderer;
    public Transform firePoint;
    [SerializeField] GameObject bullet;
    public LayerMask playerLayerMask;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _blobRigidBody = GetComponent<Rigidbody2D>();
        _blobBoxCollider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            _spriteRenderer.flipX = false;
        }
        else if(direction.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public override void TakingDmg(int dmg)
    {
        blobCurrentHealth -= dmg;
        if (blobCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void FireBullet()
    {
        RaycastHit2D rayCastBullet = Physics2D.Raycast(firePoint.position, direction, 50f, playerLayerMask);

        Instantiate(bullet,firePoint, rayCastBullet);
    }
}
