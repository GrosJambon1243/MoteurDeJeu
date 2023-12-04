using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject fireBall,axe,arrow;
    [SerializeField] private Transform fireBallSpot1,axeSpot,fireBallSpot2;
    [SerializeField] private float fireBallTimer,axeTimer,arrowTimer;
    private float fireBallCd, axeCd, arrowCd;
    private bool asFireBall,asAxe;
    private bool asArrow;

    private void Start()
    {
        fireBallCd = fireBallTimer;
        axeCd = axeTimer;
        arrowCd = arrowTimer;

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

        if (asArrow)
        {
            ShootArrow();
        }

    }

    private void ShootFireBall()
    {
        if (fireBallCd >= 0)
        {
            fireBallCd -= Time.deltaTime;
            if (fireBallCd <= 0)
            {
                Instantiate(fireBall, fireBallSpot1.transform.position,fireBallSpot1.rotation);
                Instantiate(fireBall,fireBallSpot2.transform.position,fireBallSpot2.rotation);
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
                Instantiate(axe, axeSpot.position,axeSpot.rotation);
                axeCd = axeTimer;
            }
        }
    }

    private void ShootArrow()
    {
        if (arrowCd>=0)
        {
            arrowCd -= Time.deltaTime;
            if (arrowCd <= 0 )
            {
                var position = fireBallSpot1.transform.position;
                var rotation = fireBallSpot1.rotation;
                Instantiate(arrow, position,rotation); 
                Instantiate(arrow, new Vector3(0f,1f)+ position,rotation);
                Instantiate(arrow, new Vector3(0f,-1f)+ position,rotation);
                arrowCd = arrowTimer;
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

    public void UnlockArrow()
    {
        asArrow = true;
    }

    public void IncreaseMeleeDmg()
    {
        
    }
    

}
