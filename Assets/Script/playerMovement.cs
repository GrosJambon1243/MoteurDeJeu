using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
        [SerializeField] private float speed = 1f;
        Rigidbody2D theRB;
    
        
    
        private void Start()
        {
            // animator = Getcomponent<Rigidbody2D>();
            theRB = GetComponent<Rigidbody2D>();
           
        }

        private void FixedUpdate()
        {

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            //animator.SetBool("IsWalking", Mathf.Abs(x)>0 || Mathf.Abs(y) > 0);
            theRB.velocity = new Vector3(x, y, 0f) * speed;


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
