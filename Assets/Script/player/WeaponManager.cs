using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private FireBall _fireBall;
    [SerializeField] private Axe _axe;
    [SerializeField] private Arrow _arrow;
    
    [SerializeField] private Transform fireBallSpot1,axeSpot,fireBallSpot2;
    [SerializeField] private float fireBallTimer,axeTimer,arrowTimer;
    private float fireBallCd, axeCd, arrowCd;
    private bool asFireBall,asAxe,asArrow;

    private int _fireBallLevel;
    private int _axeLevel;
    private int _arrowBallLevel;


    private void Start()
    {
        fireBallCd = fireBallTimer;
        axeCd = axeTimer;
        arrowCd = arrowTimer;
        _fireBallLevel = 0;
        _axeLevel = 0;
        _arrowBallLevel = 0;

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
        if (fireBallCd < 0) return;
        fireBallCd -= Time.deltaTime;
        switch (_fireBallLevel)
        {
            case 1:
                if (fireBallCd <= 0)
                {
                    Instantiate(_fireBall, fireBallSpot1.transform.position,fireBallSpot1.rotation);
                    Instantiate(_fireBall,fireBallSpot2.transform.position,fireBallSpot2.rotation);
                    fireBallCd = fireBallTimer;
                }
                break;
            case >1: 
                if (fireBallCd <= 0)
                {
                    Instantiate(_fireBall, fireBallSpot1.transform.position,fireBallSpot1.rotation);
                    Instantiate(_fireBall,fireBallSpot2.transform.position,fireBallSpot2.rotation);
                    Instantiate(_fireBall, fireBallSpot1.transform.position+ new Vector3(0f,1f),fireBallSpot1.rotation);
                    Instantiate(_fireBall,fireBallSpot2.transform.position + new Vector3(0f,1f),fireBallSpot2.rotation);
                    fireBallCd = fireBallTimer;
                }
                break;
        }
    }

    private void ShootAxe()
    {
        if (axeCd < 0) return;
        axeCd -= Time.deltaTime;

        switch (_axeLevel)
        {
            case 1:
                if (axeCd <= 0)
                {
                    Instantiate(_axe, axeSpot.position,axeSpot.rotation);
                    axeCd = axeTimer;
                }
                break;
            case >1:
                if (axeCd <= 0)
                {
                    Instantiate(_axe, axeSpot.position,axeSpot.rotation);
                    Instantiate(_axe, axeSpot.position+new Vector3(1f,0f),axeSpot.rotation);
                    axeCd = axeTimer;
                }
                break;
                            
        }
    }

    private void ShootArrow()
    {
        if (arrowCd < 0) return;
        arrowCd -= Time.deltaTime;
        switch (_arrowBallLevel)
        {
            case 1:
                if (arrowCd <= 0 )
                {
                    var position = fireBallSpot1.transform.position;
                    var rotation = fireBallSpot1.rotation;
                    Instantiate(_arrow, position,rotation); 
                    Instantiate(_arrow, new Vector3(0f,1f)+ position,rotation);
                    Instantiate(_arrow, new Vector3(0f,-1f)+ position,rotation);
                    arrowCd = arrowTimer;
                }

                break;
            case >1:
                if (arrowCd <= 0 )
                {
                    var position = fireBallSpot1.transform.position;
                    var rotation = fireBallSpot1.rotation;
                    Instantiate(_arrow, position,rotation); 
                    Instantiate(_arrow, new Vector3(0f,1f)+ position,rotation);
                    Instantiate(_arrow, new Vector3(0f,-1f)+ position,rotation);
                    Instantiate(_arrow, new Vector3(0f,2f)+ position,rotation);
                    Instantiate(_arrow, new Vector3(0f,-2f)+ position,rotation);
                    arrowCd = arrowTimer;
                }

                break;
                
        }
    }
   

    public void LevelUpFireBall()
    {
        switch (_fireBallLevel)
        {
            case 0:
                asFireBall = true;
                _fireBallLevel++;    
                break;
            case >0 :
                _fireBallLevel++; 
                _fireBall.LevelUp(1.5f,1.5f,2);
                
                break;
        }
        
    }

    public void UnlockAxe()
    {
        switch (_axeLevel)
        {
            case 0:
                asAxe = true;
                _axeLevel++;    
                break;
            case >0 :
                _axeLevel++;
                _axe.LevelUp(10,5,1);
                
                break;
        }
    }

    public void UnlockArrow()
    {
        switch (_arrowBallLevel)
        {
            case 0:
                asArrow = true;
               _arrowBallLevel++;    
                break;
            case >0 :
                _arrowBallLevel++;
                _arrow.LevelUp(10,5,1);
                
                break;
        }
    }
}
