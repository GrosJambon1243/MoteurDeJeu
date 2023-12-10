
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelCanvas, upgradeCanvas,mainMenuCanvas,characterCanvas;
    public void OnStartClick()
    {
        gameObject.SetActive(false);
        characterCanvas.SetActive(true);
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
        SceneManager.LoadSceneAsync(1);
    }

    public void LevelTwo()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void LevelThree()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
