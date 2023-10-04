using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    private Vector3 direction;
    [SerializeField]float moveSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (player != null)
        {
            direction = (player.transform.position - transform.position).normalized;
         
            transform.Translate(direction * (moveSpeed * Time.deltaTime));
            
        }
         
    }
    
}
