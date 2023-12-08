using System;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PostProces : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private Toggle _chromaticToggle, _vignetteToggle;

    private Vignette _vignette;
    private ChromaticAberration _chromatic;
    private GameObject player;

    private float invincibleTimer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _volume.profile.TryGet(out _chromatic);
        _volume.profile.TryGet(out _vignette);

    }

    private void Update()
    {
        if (_chromaticToggle.isOn)
        {
            if (player.GetComponent<PlayerMovement>().IsInvincible)
            {
                invincibleTimer = 1f;
            }
            else
            {
                invincibleTimer -= Time.deltaTime * 2f;
                if (invincibleTimer < 0)
                {
                    invincibleTimer = 0;
                }
            }
            _chromatic.intensity.Override(invincibleTimer);
            
        }
        else
        {
            _chromatic.active = false;
        }

        if (_vignetteToggle.isOn)
        {
            if (player.GetComponent<PlayerMovement>().CurrentHp <= 100)
            {
                _vignette.active = true;
                float x = Mathf.Sin((Time.time * 5) + 2) / 4f;
                _vignette.intensity.Override(x);
            }
            else
            {
                _vignette.active = false;
            }
            
        }
        else
        {
            _vignette.active = false;
        }
    }
    
}
