using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject fireBall,axe;
    [SerializeField] private Transform fireBallSpot1,axeSpot;
    [SerializeField] private float fireBallCd,fireBallTimer,axeCd,axeTimer;
    public bool asFireBall,asAxe;

    private void Start()
    {
        fireBallCd = fireBallTimer;
        axeCd = axeTimer;
    }

    private void FixedUpdate()
    {
        if (asFireBall)
        {
            ShootFireBall();
        }

        if (asAxe)
        {
            ShootAxe();
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

    private void ShootAxe()
    {
        if (axeCd >= 0)
        {
            axeCd -= Time.deltaTime;
            if (axeCd <= 0)
            {
                Instantiate(axe, axeSpot.position,Quaternion.identity);
                axeCd = axeTimer;
            }
        }
    }

    public void UnlockFireBall()
    {
        asFireBall = true;
    }

    public void UnlockAxe()
    {
        asAxe = true;
    }
    
}
