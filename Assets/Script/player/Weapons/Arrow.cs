using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;


public class Arrow : MonoBehaviour , IWeaponLevelUp
{
     private float arrowDmg;
     private float arrowSpeed;
    [SerializeField] private Rigidbody2D theRb;
   
   
    private void Start()
    {
        arrowDmg = 25f;
        arrowSpeed = 20f;
        gameObject.transform.localScale = new Vector3(-1f, 1f, 0f);
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

    public void LevelUp(float Damage, float Speed, int ScaleModifier)
    {
        arrowDmg *= Damage;
        arrowSpeed *= Speed;
        gameObject.transform.localScale *= ScaleModifier;
    }
}
