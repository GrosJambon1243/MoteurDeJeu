using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttack : MonoBehaviour
{
    private float _swordTimer;
    private bool canSwingSword = true;
    private float _attackTimer;
    private bool _isAttacking;
    private Animator _animator;
    [SerializeField] private float swordAtkCooldown;
    private Rigidbody2D _theRb;
    [SerializeField] private Transform swordSpot;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float swordRange;
    [SerializeField] private AudioSource swordSoundEffect;
    [SerializeField] private GameObject getsuga;
    [SerializeField] private Transform getsugaSpot;
    [SerializeField] private int swordDamage;


    void Start()
    {
        _theRb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        SwordAttack();
    }
    private void SwordAttack()
    {
        if (_swordTimer > 0)
        {
            _swordTimer -= Time.deltaTime;
            if (_swordTimer <=0)
            {
                canSwingSword = true;
            }
        }
        if (_attackTimer > 0)
        {
            _attackTimer -= Time.deltaTime;
            if (_attackTimer <=0)
            {
                _isAttacking = false;
            }
        }
            
        if (Input.GetMouseButtonDown(0) && canSwingSword)
        {
                
            _animator.SetTrigger("Attack");
            _attackTimer = 0.8f;
            canSwingSword = false;
            _isAttacking = true;
            _swordTimer = swordAtkCooldown;
            _theRb.velocity = Vector2.zero;
        }
    }
    public void FourFrameSword()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(swordSpot.position,swordRange,enemyLayers);
        swordSoundEffect.Play();
        Instantiate(getsuga, getsugaSpot.transform.position, getsugaSpot.rotation);
            
        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<enemyDamage>().TakingDmg(swordDamage);
        }
            
    }
}
