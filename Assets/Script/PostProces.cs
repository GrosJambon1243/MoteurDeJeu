using System;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PostProces : MonoBehaviour
{
    [SerializeField] private Volume _volume;

    private Vignette _vignette;
    [SerializeField] private PlayerMovement _player;
    

    private void Awake()
    {
        
        _volume.profile.TryGet(out _vignette);
    }

    private void Update()
    {
        if (_player.CurrentHp <= 100)
        {
            _vignette.active = true;
            float x = Mathf.Sin((Time.time * 10) + 2) /4f;
            _vignette.intensity.Override(x);
        }
        else
        {
            _vignette.active = false;
        }
    }
}
