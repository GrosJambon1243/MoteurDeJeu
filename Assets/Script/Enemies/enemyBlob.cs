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
    public float blobMaxHealth = 50, damageOnContact;
    private float blobCurrentHealth,_range;
    public Transform firePoint;
    [SerializeField] GameObject bullet,currency,experience,healPotion;
    private bool isKnockBack;
    private GameObject _dataCollecting;
    

    private void Start()
    {
        attackCd = attackTimer;
        player = GameObject.FindGameObjectWithTag("Player");
        _blobRigidBody = GetComponent<Rigidbody2D>();
        _blobBoxCollider2D = GetComponent<BoxCollider2D>();
        _dataCollecting = GameObject.FindGameObjectWithTag("Collecting");
       
        if ( Time.time >= 30f)
        {
            blobMaxHealth += 50;
        }
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

    public override void TakingDmg(float dmg)
    {
        base.TakingDmg(dmg);

        blobCurrentHealth -= dmg;
        if (blobCurrentHealth <= 0)
        {
            _dataCollecting.GetComponent<monsterKill>().NumberOfKill();
            
            DeathAnim(currency,experience,healPotion,transform.position,_range);
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

    public override void DeathAnim(GameObject coin, GameObject expCrystal, GameObject heal,Vector3 position, float range)
    {
        var potionDrop = Random.Range(0, 10);
        position = transform.position;
        range = Random.Range(0, 4);
        _blobBoxCollider2D.enabled = false;
        this.enabled = false;
       
        Instantiate(expCrystal,position,Quaternion.identity);
        if (range == 2)
        {
            Instantiate(coin,position + new Vector3(1f,0),Quaternion.identity);
        }

        if (potionDrop == 9)
        {
            Instantiate(heal,position + new Vector3(-1f,0),Quaternion.identity);
        }
        Destroy(gameObject, 0);
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.collider.gameObject.CompareTag("Player") )
        {
            player.GetComponent<PlayerMovement>().TakingDmg(damageOnContact);
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
