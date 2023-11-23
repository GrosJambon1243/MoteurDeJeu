using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemyDamage : MonoBehaviour
{
    public abstract void TakingDmg(int dmg);


    public abstract void DeathAnim(GameObject coin, GameObject expCrystal,GameObject heal, Vector3 position, int range);


}
