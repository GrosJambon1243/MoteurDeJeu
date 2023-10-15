using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int bulletDmg;
    private GameObject playerPosition;

    void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        rb.velocity =  (playerPosition.transform.position - transform.position)* bulletSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var thePlayer = hitInfo.GetComponent<playerMovement>();

        if (thePlayer != null)
        {
            thePlayer.TakingDmg(bulletDmg);
            Destroy(gameObject);
        }
    }
}
