using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getsuga : MonoBehaviour
{
    [SerializeField] private int projectileDmg = 100;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private Rigidbody2D theRb;
    private void Start()
    {

        theRb.velocity = transform.right * projectileSpeed;

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
            theEnemies.TakingDmg(projectileDmg);
        }
    }
}
