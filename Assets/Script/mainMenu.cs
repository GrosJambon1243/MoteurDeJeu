using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelCanvas, upgradeCanvas;
    public void OnStartClick()
    {
        gameObject.SetActive(false);
        levelCanvas.SetActive(true);
    }
}
