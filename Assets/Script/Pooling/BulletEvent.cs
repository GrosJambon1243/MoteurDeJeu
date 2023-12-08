using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEvent : PoolObject
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int bulletDmg;
    [SerializeField] private float lifeTime = 5f;
    private Vector3 initalPosition;
    
    void Start()
    {
        initalPosition = transform.position;
        rb.velocity = Vector2.left * bulletSpeed;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            transform.position = initalPosition;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var thePlayer = hitInfo.GetComponent<PlayerMovement>();

        if (thePlayer != null)
        {
            thePlayer.TakingDmg(bulletDmg);
            gameObject.SetActive(false);
            transform.position = initalPosition;
        }
    }

    public override void Reset()
    {
        lifeTime = 10f;
    }
}
