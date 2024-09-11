using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Axe : MonoBehaviour, IWeaponLevelUp
{
    private float axeDmg;
    private float axeSpeed;
    [SerializeField] private Rigidbody2D theRb;
   
    private void Start()
    {
        axeDmg = 50f;
        axeSpeed = 20f;
        gameObject.transform.localScale = new Vector3(1.7f, 1.7f, 0f);
        theRb.velocity = (Vector2.one + Vector2.up) * axeSpeed;

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
            theEnemies.TakingDmg(axeDmg);
        }
    }

    public void LevelUp(float Damage, float Speed, int ScaleModifier)
    {
        axeDmg *= Damage;
        axeSpeed *= Speed;
        gameObject.transform.localScale *= ScaleModifier;
    }
}
