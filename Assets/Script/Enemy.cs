using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D _skeleRigidBody;
    private Vector3 direction;
    [SerializeField]float moveSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _skeleRigidBody = GetComponent<Rigidbody2D>();
    }

    

    private void FixedUpdate()
    {
        if (player != null)
        {
            direction = (player.transform.position - transform.position).normalized;

            _skeleRigidBody.velocity = direction * (moveSpeed * Time.fixedDeltaTime);

        }
    }
}
