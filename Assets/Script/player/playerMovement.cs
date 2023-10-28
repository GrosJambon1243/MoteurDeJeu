
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
    [SerializeField] private Transform getsugaSpot;
    [SerializeField] private GameObject getsuga;
    [SerializeField] private float swordAtkCoold = 0;
    private float swordTimer,attackTimer,x,y;
    public float swordRange =0.5f;
    public int swordDamage = 50, maxHealth = 100;
    [HideInInspector]
    [SerializeField] private bool canSwingSword;
    private bool isAttacking,isInvincible,_isFacingRight = true,boolExitCanvas;
    public Transform swordSpot;
    public LayerMask enemyLayers;
    public healthBar hpBar;
    public int currentHealth;
    [SerializeField] private GameObject exitCanvas;

    #endregion
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
        private void Start()
        {
            isInvincible = false;
            currentHealth = maxHealth;
            _theRb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _animator.SetInteger("AnimState",1);
            
            hpBar.SetMaxHealth(maxHealth);
            hpBar.SetHealth(currentHealth,maxHealth);
        }

        private void Update()
        {
            ExitButton();
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
                gameObject.SetActive(false);
                Time.timeScale = 0;
            }
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

        private void ExitButton()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                boolExitCanvas = !boolExitCanvas;
                exitCanvas.SetActive(boolExitCanvas);
                Time.timeScale = boolExitCanvas ? 0 : 1; // Freeze game when exit panel is active.
            }
           
           
        }
}
