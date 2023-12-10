using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCharacter : MonoBehaviour
{
    [SerializeField] private GameObject warrior, samurai;
    

    private void Awake()
    {
        int selectedChracter = CharacterSelector.characterSelected;
        switch (selectedChracter)
        {
            case 1:
                warrior.SetActive(true);
                break;
            case 2:
                samurai.SetActive(true);
                break;
            default:
                Debug.Log("Invalid");
                break;
        }
    }

   
}
