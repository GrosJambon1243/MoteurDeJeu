
using UnityEngine;

public class experienceDiamond : MonoBehaviour
{
    public float expGain = 20;
    private Vector3 _direction;
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
           _dataCollecting.GetComponent<monsterKill>().NumberExp();
            _gameManager.GainExperience(expGain);
            Destroy(gameObject);
        }
    }
}
