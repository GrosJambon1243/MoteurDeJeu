using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experienceDiamond : MonoBehaviour
{
    public float expGain = 10;
    private Vector3 _direction;
    private gameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<gameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            Debug.Log("lol");
            _gameManager.GainExperience(expGain);
            Destroy(gameObject);
        }
    }
}
