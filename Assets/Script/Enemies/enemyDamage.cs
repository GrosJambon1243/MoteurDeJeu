using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    protected SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public virtual void TakingDmg(int dmg)
    {
        StartCoroutine(Flashing());
    }


    public virtual void DeathAnim(GameObject coin, GameObject expCrystal, GameObject heal, Vector3 position, int range)
    {
    }

    public IEnumerator Flashing()
    {
        _sprite.material.SetFloat("_HurtValue", 0.9f);
        yield return new WaitForSeconds(0.1f);
        _sprite.material.SetFloat("_HurtValue", 0.8f);
        yield return new WaitForSeconds(0.1f);
        _sprite.material.SetFloat("_HurtValue", 0.6f);
        yield return new WaitForSeconds(0.1f);
        _sprite.material.SetFloat("_HurtValue", 0.4f);
        yield return new WaitForSeconds(0.1f);
        _sprite.material.SetFloat("_HurtValue", 0f);
    }

}
