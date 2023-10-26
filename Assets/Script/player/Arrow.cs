using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    [SerializeField] private int arrowDmg = 25;
    [SerializeField] float arrowSpeed = 20f;
    [SerializeField] private Rigidbody2D theRb;
    
   
    
    private void Start()
    {
        theRb.velocity = transform.right * arrowSpeed;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var theEnemies = hitInfo.GetComponent<enemyDamage>();

        if (theEnemies != null)
        {
            theEnemies.TakingDmg(arrowDmg);
        }
    }
}
