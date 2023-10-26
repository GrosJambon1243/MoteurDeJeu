using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject fireBall,axe,bible;
    [SerializeField] private Transform fireBallSpot1,axeSpot,bibleSpot,fireBallSpot2;
    [SerializeField] private float fireBallCd,fireBallTimer,axeCd,axeTimer,bibleCd,bibleTimer;
    public bool asFireBall,asAxe;

    private void Start()
    {
        fireBallCd = fireBallTimer;
        axeCd = axeTimer;
        bibleCd = bibleTimer;
        

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

        if (Input.GetKeyDown(KeyCode.K))
        {
            
         Instantiate(bible, bibleSpot.position + new Vector3(2,0), bibleSpot.rotation);
        }
    }

    private void ShootFireBall()
    {
        if (fireBallCd >= 0)
        {
            fireBallCd -= Time.deltaTime;
            if (fireBallCd <= 0)
            {
                var position = fireBallSpot1.position;
                Instantiate(fireBall, position,fireBallSpot1.rotation);
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
                Instantiate(axe, axeSpot.position,Quaternion.identity);
                axeCd = axeTimer;
            }
        }
    }
    public void RotateBible()
    {
        if (bibleCd >= 0)
        {
            bibleCd -= Time.deltaTime;
            if (bibleCd <= 0)
            {

                bibleCd = bibleTimer;
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
