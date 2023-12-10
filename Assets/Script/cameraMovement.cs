using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField]  int zoom = -10;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        Vector3 position = player.transform.position;
        position.z = zoom;
        transform.position = position;
    }
}
