using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject fireBall,axe;
    [SerializeField] private Transform fireBallSpot1,axeSpot;
    [SerializeField] private float fireBallCd,fireBallTimer;
    public bool asFireBall = false;

    private void Start()
    {
        fireBallCd = fireBallTimer;
    }

    private void FixedUpdate()
    {
        if (asFireBall)
        {
            ShootFireBall();
        }
        
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

    public void UnlockFireBall()
    {
        asFireBall = true;
    }
    
}
