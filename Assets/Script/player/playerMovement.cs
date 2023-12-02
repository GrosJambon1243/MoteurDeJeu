
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variable
    [SerializeField] private AudioSource swordSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;
// General UI
    [SerializeField] private GameObject GeneralUi;
// Movement
    [SerializeField] private float speed = 1f;
    private float _x, _y;

// Game Over
    [SerializeField] private GameObject gameOverCanvas;
    private GameObject _dataCollecting;

// Animator and Rigidbody
    private Animator _animator;
    private Rigidbody2D _theRb;

// Sword Attack
    [SerializeField] private Transform getsugaSpot;
    [SerializeField] private GameObject getsuga;
    [SerializeField] private float swordAtkCooldown;
    private float _swordTimer, _attackTimer;
    [SerializeField] private bool canSwingSword;

// Attack Parameters
    [SerializeField] private float swordRange = 0.5f;
    public int swordDamage = 50;

// Player Health
    public int maxHealth = 100;
    private bool _isInvincible;

    public bool IsInvincible
    {
        get => _isInvincible;
    }
    private bool _isAttacking;

// Facing Direction
    private bool _isFacingRight = true;

// Exit Canvas
    [SerializeField] private GameObject exitCanvas;
    private bool _boolExitCanvas;

// Sword Attack Spot and Enemy Layers
    public Transform swordSpot;
    public LayerMask enemyLayers;

// Health Bar
    public healthBar hpBar;
    private int _currentHealth;

    public int CurrentHp
    {
        get => _currentHealth;
        private set => _currentHealth = value;
    }

 

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
            _isInvincible = false;
            _currentHealth = maxHealth;
            _theRb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _animator.SetInteger("AnimState",1);
            _dataCollecting = GameObject.FindGameObjectWithTag("Collecting");
            hpBar.SetMaxHealth(maxHealth);
            hpBar.SetHealth(_currentHealth,maxHealth);
        }

        private void Update()
        {
            ExitButton();
            HandleMovement();
            SwordAttack();
        }


   

        private void HandleMovement()
        {
            _x = Input.GetAxisRaw("Horizontal");
            _y = Input.GetAxisRaw("Vertical");
            if (!_isAttacking)
            {
                _theRb.velocity = new Vector3(_x, _y, 0f).normalized * (speed * Time.fixedDeltaTime);
                _animator.SetInteger("AnimState", _theRb.velocity != Vector2.zero ? 2 : 1);
                Flip();
            }
        }

        private void Flip()
        {
            if ((_x < 0 && _isFacingRight) ||(_x > 0 && !_isFacingRight))
            {
                _isFacingRight = !_isFacingRight;
                transform.Rotate(0f,180f,0f);
            }
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

        public void TakingDmg(int damage)
        {
            if (!_isInvincible)
            {
                _currentHealth -= damage;
                hpBar.SetHealth(_currentHealth,maxHealth);
                _isInvincible = true;
                _isAttacking = false;
                _animator.SetTrigger("Hurt");
                hurtSoundEffect.Play();
                Invoke("PlayerInvinsible",1);
            }
           
            if (_currentHealth<= 0)
            {
                hpBar.SetHealth(0,maxHealth);
                GeneralUi.SetActive(false);
                _animator.SetTrigger("Death");
                StartCoroutine(DeathAnimation());
            }
        }
        private void PlayerInvinsible()
        {
            _isInvincible = false;
        }
        public void HealingPlayer(int healing)
        {
                var maxHealing = maxHealth - _currentHealth;
                var actualHealing = Mathf.Min(healing, maxHealing);
                _currentHealth += actualHealing;
                hpBar.SetHealth(_currentHealth,maxHealth);
        }
        public void IncreaseSwordDmg()
        {
            swordDamage += 50;
        }

        private void ExitButton()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _boolExitCanvas = !_boolExitCanvas;
                exitCanvas.SetActive(_boolExitCanvas);
                Time.timeScale = _boolExitCanvas ? 0 : 1; 
            }
           
        }

        private IEnumerator DeathAnimation()
        {
            yield return new WaitForSeconds(2f);
            gameOverCanvas.SetActive(true);
            _dataCollecting.GetComponent<monsterKill>().MonsterText();
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }


        
}


