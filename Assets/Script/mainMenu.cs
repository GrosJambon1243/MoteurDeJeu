using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelCanvas, upgradeCanvas,mainMenuCanvas;
    public void OnStartClick()
    {
        gameObject.SetActive(false);
        levelCanvas.SetActive(true);
    }

    public void ReturnToMain()
    {
        gameObject.SetActive(false);
        mainMenuCanvas.SetActive(true);
        
    }

    public void UpgradeButton()
    {
        upgradeCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
    }
}
