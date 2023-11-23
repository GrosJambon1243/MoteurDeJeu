using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Players : MonoBehaviour
{
    public abstract void Attacking(float cd, float timer, bool canAttack);



}
