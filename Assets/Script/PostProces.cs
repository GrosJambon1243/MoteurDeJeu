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

    private void Start()
    {
        _volume.profile.TryGet(out _chromatic);
        _volume.profile.TryGet(out _vignette);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        switch (_chromaticToggle.isOn)
        {
            case true:
            {
                _chromatic.active = true;
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
                break;
            }
            case false:
                _chromatic.active = false;
                break;
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
