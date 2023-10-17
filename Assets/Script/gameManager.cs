using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    
    [SerializeField] private Transform[] spawPoints;
    [SerializeField] private GameObject skeleton, blob;
    [SerializeField] private experienceBar experienceBar;
    private float timeUntilSpawn = 5f, spawnTimer;
    
    public float  expMax = 100, currentExp, expAddition = 100, expLevel;
    public AudioSource lvlUpSound;

    private void Start()
    {
        spawnTimer = timeUntilSpawn;
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

    private void FixedUpdate()
    {
        
        SpawnEnemies();
        
    }

    public void SpawnEnemies()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer<= 0)
            {
                Instantiate(skeleton, spawPoints[0].transform.position,quaternion.identity);
                Instantiate(skeleton, spawPoints[1].transform.position,quaternion.identity);
                Instantiate(blob, spawPoints[2].transform.position,quaternion.identity);
                
                spawnTimer = timeUntilSpawn;
            }
        }
    }
}
