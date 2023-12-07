using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] private float currencyValue;
    
    private gameManager _gameManager;
    private GameObject _dataCollecting;

    private void Start()
    {
        _dataCollecting = GameObject.FindGameObjectWithTag("Collecting");
        _gameManager = FindObjectOfType<gameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            _dataCollecting.GetComponent<monsterKill>().NumberCoin();
            _gameManager.GainCurrency(currencyValue);
            Destroy(gameObject);
        }
    }
}
