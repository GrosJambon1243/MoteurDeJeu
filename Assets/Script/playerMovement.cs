
using UnityEngine;

public class playerMovement : MonoBehaviour
{
        [SerializeField] private float speed = 1f;
        private Animator _animator;
        Rigidbody2D theRB;
    
        
    
        private void Start()
        {
            
            theRB = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

        }

        private void FixedUpdate()
        {

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            
            theRB.velocity = new Vector3(x, y, 0f) * speed;

            if (theRB.velocity != Vector2.zero)
            {
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _animator.SetBool("isWalking", false);
            }
            if (x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
}
