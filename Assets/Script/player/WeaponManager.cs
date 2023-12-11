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
    private int fireBallLevel, axeLevel, arrowLevel;

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
            switch (fireBallLevel)
            {
                case 1:
                    if (fireBallCd <= 0)
                    {
                        Instantiate(fireBall, fireBallSpot1.transform.position,fireBallSpot1.rotation);
                        Instantiate(fireBall,fireBallSpot2.transform.position,fireBallSpot2.rotation);
                        fireBallCd = fireBallTimer;
                    }
                    break;
                case 2: 
                    if (fireBallCd <= 0)
                    {
                        Instantiate(fireBall, fireBallSpot1.transform.position,fireBallSpot1.rotation);
                        Instantiate(fireBall,fireBallSpot2.transform.position,fireBallSpot2.rotation);
                        Instantiate(fireBall, fireBallSpot1.transform.position+ new Vector3(0f,1f),fireBallSpot1.rotation);
                        Instantiate(fireBall,fireBallSpot2.transform.position + new Vector3(0f,1f),fireBallSpot2.rotation);
                        fireBallCd = fireBallTimer;
                    }
                    break;
            }
            
           
        }
    }

    private void ShootAxe()
    {
        if (axeCd >= 0)
        {
            axeCd -= Time.deltaTime;

            switch (axeLevel)
            {
                case 1:
                    if (axeCd <= 0)
                    {
                        Instantiate(axe, axeSpot.position,axeSpot.rotation);
                        axeCd = axeTimer;
                    }
                    break;
                case 2:
                    if (axeCd <= 0)
                    {
                        Instantiate(axe, axeSpot.position,axeSpot.rotation);
                        Instantiate(axe, axeSpot.position+new Vector3(1f,0f),axeSpot.rotation);
                        axeCd = axeTimer;
                    }
                    break;
                            
            }
        }
    }

    private void ShootArrow()
    {
        if (arrowCd>=0)
        {
            arrowCd -= Time.deltaTime;
            switch (arrowLevel)
            {
                case 1:
                    if (arrowCd <= 0 )
                    {
                        var position = fireBallSpot1.transform.position;
                        var rotation = fireBallSpot1.rotation;
                        Instantiate(arrow, position,rotation); 
                        Instantiate(arrow, new Vector3(0f,1f)+ position,rotation);
                        Instantiate(arrow, new Vector3(0f,-1f)+ position,rotation);
                        arrowCd = arrowTimer;
                    }

                    break;
                case 2:
                    if (arrowCd <= 0 )
                    {
                        var position = fireBallSpot1.transform.position;
                        var rotation = fireBallSpot1.rotation;
                        Instantiate(arrow, position,rotation); 
                        Instantiate(arrow, new Vector3(0f,1f)+ position,rotation);
                        Instantiate(arrow, new Vector3(0f,-1f)+ position,rotation);
                        Instantiate(arrow, new Vector3(0f,2f)+ position,rotation);
                        Instantiate(arrow, new Vector3(0f,-2f)+ position,rotation);
                        arrowCd = arrowTimer;
                    }

                    break;
                
            }
        }
    }
   

    public void UnlockFireBall()
    {
        if (fireBallLevel == 2)
        {
            fireBallLevel = 2;
        }
        else
        {
            fireBallLevel++;
        }
        asFireBall = true;
    }

    public void UnlockAxe()
    {
        if (axeLevel == 2)
        {
            axeLevel = 2;
        }
        else
        {
            axeLevel++;
        }
        asAxe = true;
    }

    public void UnlockArrow()
    {
        if (arrowLevel == 2)
        {
           arrowLevel = 2;
        }
        else
        {
            arrowLevel++;
        }
        asArrow = true;
    }
}
