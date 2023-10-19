using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUi : MonoBehaviour
{
    private WeaponManager _weaponManager;
    

    public void FireBallButton()
    {
        _weaponManager = FindObjectOfType<WeaponManager>();
        _weaponManager.UnlockFireBall();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void AxeButton()
    {
        _weaponManager = FindObjectOfType<WeaponManager>();
        _weaponManager.UnlockAxe();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
