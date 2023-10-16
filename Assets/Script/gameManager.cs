using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawPoints;
    [SerializeField] private GameObject skeleton, blob;
    [SerializeField] private experienceBar experienceBar;
    
    public float  expMax = 100, currentExp, expAddition = 100, expLevel;
    public AudioSource lvlUpSound;

    private void Start()
    {
        experienceBar.SetMaxExperience(expMax);
        experienceBar.SetExperience(0);
    }


    public void GainExperience(float expGain)
    {
        currentExp += expGain;
        experienceBar.SetExperience(currentExp);
        if (currentExp == expMax)
        {
            lvlUpSound.Play();
            currentExp = 0;
            experienceBar.SetExperience(0);
            expLevel = expMax + expAddition;
            expMax = expLevel;
            experienceBar.SetMaxExperience(expMax);
            

        }
    }
}
