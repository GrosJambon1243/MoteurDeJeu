
using System;
using UnityEngine;
using UnityEngine.Timeline;

public class playerMovement : MonoBehaviour
{
        [SerializeField] private float speed = 1f;
        private Animator _animator;
        private Rigidbody2D _theRb;
        private SpriteRenderer _sprite;
        [SerializeField] private float swordAtkCoold = 0;
        [SerializeField] private bool canSwingSword;
        public Transform swordSpot;
        public float swordRange =0.5f;
        public LayerMask enemyLayers;
        public int swordDamage = 50, maxHealth = 100;
        public healthBar hpBar;
        [HideInInspector]
        public int currentHealth;
        
        
    
            
    
        private void Start()
        {
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

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            
            _theRb.velocity = new Vector3(x, y, 0f).normalized * (speed * Time.fixedDeltaTime);
            _animator.SetInteger("AnimState", _theRb.velocity != Vector2.zero ? 2 : 1);
            if (x < 0)
            {
                _sprite.flipX = false;
            }
            else if (x > 0)
            {
                _sprite.flipX = true;
            }

            if (Input.GetMouseButton(0) && canSwingSword)
            {
                SwordAttack();
            }

        }

        public void SwordAttack()
        {
                _animator.SetTrigger("Attack");
                canSwingSword = false;
                // hitEnemys est un array qui store les enemy qui sont hit ; OverlapCircleAll creer un cercle autour d'un point avec un radius;
                
                Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(swordSpot.position,swordRange,enemyLayers);

                foreach (Collider2D enemy in hitEnemys)
                {
                    enemy.GetComponent<Enemy>().TakingDmg(swordDamage);
                }
                Invoke("SwordCoolDown",swordAtkCoold);
        }

        public void TakingDmg(int damage)
        {
            currentHealth -= damage;
            hpBar.SetHealth(currentHealth,maxHealth);
        }
        
        public void SwordCoolDown()
        {
            canSwingSword = true;
        }
        
        //Permet de voir le range du sword attack
        void OnDrawGizmosSelected()
        {
            if (swordSpot == null)
                return;
            Gizmos.DrawWireSphere(swordSpot.position,swordRange);
        }
}
