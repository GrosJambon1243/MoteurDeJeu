using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static int characterSelected;
    [SerializeField] private GameObject levelSelector;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void WarriorSelected()
    {
        characterSelected = 1;
        gameObject.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void SamuraiSelected()
    {
        characterSelected = 2;
        gameObject.SetActive(false);
        levelSelector.SetActive(true);
    }
}
