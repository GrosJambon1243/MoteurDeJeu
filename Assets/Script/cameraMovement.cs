using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField]  int zoom = -10;
    

    

    private void LateUpdate()
    {
        
        Vector3 position = player.transform.position;
        position.z = zoom;
        transform.position = position;
    }
}
