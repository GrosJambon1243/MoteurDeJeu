
using UnityEngine;

public class playerMovement : MonoBehaviour
{
        [SerializeField] private float speed = 1f;
        private Animator _animator;
        private Rigidbody2D _theRb;
    
            
    
        private void Start()
        {
            
            _theRb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

        }

        private void FixedUpdate()
        {

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            
            _theRb.velocity = (new Vector3(x, y, 0f).normalized * speed);

            _animator.SetBool("isWalking", _theRb.velocity != Vector2.zero);
            if (x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }


        }
        
        private void PunchAttack()
        {
            
            
        }
}
