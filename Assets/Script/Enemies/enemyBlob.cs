using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyBlob : enemyDamage
{
    private GameObject player;
    private Rigidbody2D _blobRigidBody;
    private BoxCollider2D _blobBoxCollider2D;
    private Vector3 direction;
    [SerializeField]float moveSpeed,attackTimer;
    private float attackCd;
    public int blobMaxHealth = 100, damageOnContact;
    private int blobCurrentHealth,_range;
    public Animator animator;
    public Transform firePoint;
    [SerializeField] GameObject bullet,currency,experience;
    private bool isKnockBack;

    private void Start()
    {
        attackCd = attackTimer;
        player = GameObject.FindGameObjectWithTag("Player");
        _blobRigidBody = GetComponent<Rigidbody2D>();
        _blobBoxCollider2D = GetComponent<BoxCollider2D>();
       
        blobCurrentHealth = blobMaxHealth;
    }

    private void FixedUpdate()
    {
        if (player != null && !isKnockBack)
        {
            direction = (player.transform.position - transform.position).normalized;

            _blobRigidBody.velocity = direction * (moveSpeed * Time.fixedDeltaTime);
        }
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if(direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        ShootBullet();
    }

    public override void TakingDmg(int dmg)
    {
        blobCurrentHealth -= dmg;
        animator.SetTrigger("isHurt");
        if (blobCurrentHealth <= 0)
        {
            DeathAnim(currency,experience,transform.position,_range);
        }
    }

    private void ShootBullet()
    {
        
        if (attackCd > 0 )
        {
            attackCd -= Time.deltaTime;
            if (attackCd <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                attackCd = attackTimer;
            }
        }
       
    }

    public override void DeathAnim(GameObject coin, GameObject expCrystal,Vector3 position, int range)
    {
        range = Random.Range(0, 4);
        position = transform.position;
        _blobBoxCollider2D.enabled = false;
        this.enabled = false;
        Instantiate(expCrystal,position,Quaternion.identity);
        if (range == 2)
        {
            Instantiate(coin,position + new Vector3(0.7f,0),Quaternion.identity);
        }
        Destroy(gameObject,0);
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.collider.gameObject.CompareTag("Player") )
        {
            player.GetComponent<playerMovement>().TakingDmg(damageOnContact);
            StartCoroutine(KnockBack());
        }
    }

    private IEnumerator KnockBack()
    {
        isKnockBack = true;
       
        _blobRigidBody.velocity = new Vector2((transform.position.x - player.transform.position.x),
            (transform.position.y - player.transform.position.y)).normalized * 10;
        yield return new WaitForSeconds(0.1f);
        _blobRigidBody.velocity = new Vector2((transform.position.x - player.transform.position.x),
            (transform.position.y - player.transform.position.y)).normalized * 5;
        yield return new WaitForSeconds(0.2f);
        _blobRigidBody.velocity = new Vector2((transform.position.x - player.transform.position.x),
            (transform.position.y - player.transform.position.y)).normalized * 2;
        yield return new WaitForSeconds(0.2f);
        isKnockBack = false;
       
    }
}
