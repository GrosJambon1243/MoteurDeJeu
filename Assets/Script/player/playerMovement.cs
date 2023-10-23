
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;


public class playerMovement : MonoBehaviour
{
    #region variable
    [SerializeField] private AudioSource swordSoundEffect, hurtSoundEffect;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject gameOverCanvas;
    private Animator _animator;
    private Rigidbody2D _theRb;
    private SpriteRenderer _sprite;
    private bool isAttacking,isInvincible,_isFacingRight = true;
    [SerializeField] private float swordAtkCoold = 0;
    [SerializeField] private bool canSwingSword;
    private float swordTimer,attackTimer,x,y;
       
    public Transform swordSpot,fireBallSpot1;
        
    public float swordRange =0.5f;
    public LayerMask enemyLayers;
    public int swordDamage = 50, maxHealth = 100;
    public healthBar hpBar;
    [HideInInspector]
    public int currentHealth;
    

    #endregion
        public void FourFrameSword()
        {
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(swordSpot.position,swordRange,enemyLayers);
            swordSoundEffect.Play();

            foreach (Collider2D enemy in hitEnemys)
            {
                enemy.GetComponent<enemyDamage>().TakingDmg(swordDamage);
            }
            
        }
        private void Start()
        {
            
            
            isInvincible = false;
            currentHealth = maxHealth;
            _theRb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>();
            _animator.SetInteger("AnimState",1);
            
            hpBar.SetMaxHealth(maxHealth);
            hpBar.SetHealth(currentHealth,maxHealth);
        }
        

        private void FixedUpdate()
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
            if (!isAttacking)
            {
                _theRb.velocity = new Vector3(x, y, 0f).normalized * (speed * Time.fixedDeltaTime);
                _animator.SetInteger("AnimState", _theRb.velocity != Vector2.zero ? 2 : 1);
                Flip();
            }
            SwordAttack();

        }

        private void Flip()
        {
            if ((x < 0 && _isFacingRight) ||(x > 0 && !_isFacingRight))
            {
                _isFacingRight = !_isFacingRight;
                transform.Rotate(0f,180f,0f);
            }
        }
        
        
        private void SwordAttack()
        {
            if (swordTimer > 0)
            {
                swordTimer -= Time.deltaTime;
                if (swordTimer <=0)
                {
                    canSwingSword = true;
                }
            }
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <=0)
                {
                    isAttacking = false;
                }
            }
            
            if (Input.GetMouseButton(0) && canSwingSword)
            {
                
                _animator.SetTrigger("Attack");
                attackTimer = 0.8f;
                canSwingSword = false;
                isAttacking = true;
                swordTimer = swordAtkCoold;
                _theRb.velocity = Vector2.zero;

            }
               
        }

        public void TakingDmg(int damage)
        {
            if (!isInvincible)
            {
                currentHealth -= damage;
                hpBar.SetHealth(currentHealth,maxHealth);
                isInvincible = true;
                isAttacking = false;
                _animator.SetTrigger("Hurt");
                hurtSoundEffect.Play();
                Invoke("PlayerInvinsible",1);
            }
           
            if (currentHealth<= 0)
            {
                hpBar.SetHealth(0,maxHealth);
                _animator.SetTrigger("Death");
                gameOverCanvas.SetActive(true);
                Time.timeScale = 0;
                gameObject.SetActive(false);
            }
        }
        
        //Permet de voir le range du sword attack
        void OnDrawGizmosSelected()
        {
            if (swordSpot == null)
                return;
            Gizmos.DrawWireSphere(swordSpot.position,swordRange);
        }
        

        private void PlayerInvinsible()
        {
            isInvincible = false;
        }

        public void HealingPlayer(int healing)
        {

            currentHealth += healing;
            hpBar.SetHealth(currentHealth,maxHealth);
        }

        public void IncreaseSwordDmg()
        {
            swordDamage += 50;
        }
      
}
