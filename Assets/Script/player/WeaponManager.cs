using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform fireBallSpot1,fireBallSpot2;
    [SerializeField] private float fireBallCd,fireBallTimer;

    private void Start()
    {
        fireBallCd = fireBallTimer;
    }

    private void FixedUpdate()
    {
        
        ShootFireBall();
    }

    private void ShootFireBall()
    {
        if (fireBallCd >= 0)
        {
            fireBallCd -= Time.deltaTime;
            if (fireBallCd <= 0)
            {
                Instantiate(fireBall, fireBallSpot1.position,fireBallSpot1.rotation);
                
                fireBallCd = fireBallTimer;
            }
        }
    }
}
