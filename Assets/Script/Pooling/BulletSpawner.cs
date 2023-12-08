using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            var bullet = _pool.GetObject();
            bullet.transform.SetPositionAndRotation(bullet.transform.position,Quaternion.identity);
            bullet.gameObject.SetActive(true);
            yield return new WaitForSeconds(6f);
        }
        
    }
}
