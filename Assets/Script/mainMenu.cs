using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("FirstLevel", LoadSceneMode.Single);
    }
}
