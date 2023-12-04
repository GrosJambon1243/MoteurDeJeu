

using System.Collections;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variable
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
    private SpriteRenderer _sprite;
    private Animator _animator;
    private Rigidbody2D _theRb;
// Player Health
    public int maxHealth = 100;
    private bool _isInvincible;
    public bool IsInvincible
    {
        get => _isInvincible;
    }


// Facing Direction
    private bool _isFacingRight = true;

// Exit Canvas
    [SerializeField] private GameObject exitCanvas;
    private bool _boolExitCanvas;
// Health Bar
    public healthBar hpBar;
    private int _currentHealth;

    public int CurrentHp
    {
        get => _currentHealth;
        private set => _currentHealth = value;
    }
    #endregion

    private void Awake()
    {
        _dataCollecting = GameObject.FindGameObjectWithTag("Collecting"); 
        _theRb = GetComponent<Rigidbody2D>(); 
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

  
        private void Start()
        {
            _isInvincible = false;
            _currentHealth = maxHealth;
            _animator.SetInteger("AnimState",1);
            hpBar.SetMaxHealth(maxHealth);
            hpBar.SetHealth(_currentHealth,maxHealth);
        }

        private void Update()
        {
            ExitButton();
            HandleMovement();
            
        }
        private void HandleMovement()
        {
            _x = Input.GetAxisRaw("Horizontal");
            _y = Input.GetAxisRaw("Vertical");
            _theRb.velocity = new Vector3(_x, _y, 0f).normalized * (speed * Time.fixedDeltaTime);
            _animator.SetInteger("AnimState", _theRb.velocity != Vector2.zero ? 2 : 1);
            Flip();
            
        }

        private void Flip()
        {
            if ((_x < 0 && _isFacingRight) ||(_x > 0 && !_isFacingRight))
            {
                _isFacingRight = !_isFacingRight;
                transform.Rotate(0f,180f,0f);
            }
        }
        public void TakingDmg(int damage)
        {
            if (!_isInvincible)
            {
                _currentHealth -= damage;
                hpBar.SetHealth(_currentHealth,maxHealth);
                _isInvincible = true;
               
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
            StartCoroutine(FlashingHeal());            
                var maxHealing = maxHealth - _currentHealth;
                var actualHealing = Mathf.Min(healing, maxHealing);
                _currentHealth += actualHealing;
                hpBar.SetHealth(_currentHealth,maxHealth);
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
        public IEnumerator FlashingHeal()
        {
            _sprite.material.SetFloat("_Value", 0f);
            yield return new WaitForSeconds(0.1f);
            _sprite.material.SetFloat("_Value", 0.2f);
            yield return new WaitForSeconds(0.1f);
            _sprite.material.SetFloat("_Value", 0.4f);
            yield return new WaitForSeconds(0.1f);
            _sprite.material.SetFloat("_Value", 0.6f);
            yield return new WaitForSeconds(0.1f);
            _sprite.material.SetFloat("_Value", 0.8f);
            yield return new WaitForSeconds(0.1f);
            _sprite.material.SetFloat("_Value", 1f);
        }


        
}


