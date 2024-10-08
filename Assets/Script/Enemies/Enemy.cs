using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : enemyDamage
{
    private GameObject player;
    private Rigidbody2D _skeleRigidBody;
    private BoxCollider2D _boxCollider2D;
    private Vector3 direction;
    private int deathCount;
    [SerializeField] float moveSpeed;
    public float maxHealth, damageDone;
    private float currentHealth,_range;
    public Animator animator;
    private bool isKnockBack;
    private GameObject _dataCollecting;
    [SerializeField] GameObject currency, experience,healPotion;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        _skeleRigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _dataCollecting = GameObject.FindGameObjectWithTag("Collecting");
        if ( Time.time > 30f)
        {
            maxHealth += 50;
        }
        currentHealth = maxHealth;
    }



    private void FixedUpdate()
    {
        if (player != null && !isKnockBack)
        {
            direction = (player.transform.position - transform.position).normalized;

           _skeleRigidBody.velocity = direction * (moveSpeed * Time.fixedDeltaTime);
            animator.SetInteger("isWalking", 1);

        }

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }


       
    }

    public override void TakingDmg(float dmg)
    {
        base.TakingDmg(dmg);
        currentHealth -= dmg;

        animator.SetTrigger("isHurt");
        if (currentHealth <= 0)
        {
            _dataCollecting.GetComponent<monsterKill>().NumberOfKill();
            animator.SetTrigger("isHurt");
            DeathAnim(currency, experience,healPotion,transform.position,_range);
        }
    }


    public override void DeathAnim(GameObject coin, GameObject expCrystal,GameObject heal,Vector3 position, float range)
    {
        var potionDrop = Random.Range(0, 10);
        position = transform.position;
        range = Random.Range(0, 4);
        _boxCollider2D.enabled = false;
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
            player.GetComponent<PlayerMovement>().TakingDmg(damageDone);
            StartCoroutine(KnockBack());
        }
    }

    private IEnumerator KnockBack()
    {
        isKnockBack = true;
        animator.SetInteger("isWalking", 0);
        _skeleRigidBody.velocity = new Vector2((transform.position.x - player.transform.position.x),
            (transform.position.y - player.transform.position.y)).normalized * 10;
        yield return new WaitForSeconds(0.1f);
        _skeleRigidBody.velocity = new Vector2((transform.position.x - player.transform.position.x),
            (transform.position.y - player.transform.position.y)).normalized * 5;
        yield return new WaitForSeconds(0.2f);
        _skeleRigidBody.velocity = new Vector2((transform.position.x - player.transform.position.x),
            (transform.position.y - player.transform.position.y)).normalized * 2;
        yield return new WaitForSeconds(0.2f);
        isKnockBack = false;
       
    }
}