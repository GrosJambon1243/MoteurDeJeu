using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    [SerializeField] private int bibleDmg;
    [SerializeField] private int bibleSpeed;
    [SerializeField] private Rigidbody2D theRb;
    public float rotationSpeed;
    public GameObject pivotObject;

    private void Update()
    {
        
        transform.RotateAround(pivotObject.transform.position,new Vector3(0,0,1f),rotationSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var theEnemies = hitInfo.GetComponent<enemyDamage>();

        if (theEnemies != null)
        {
            theEnemies.TakingDmg(bibleDmg);
        }
    }
}
