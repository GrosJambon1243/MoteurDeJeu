using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Ui_Bar
{
    public class ExitScript : MonoBehaviour
    {
        public void ExitButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(0);
        }
    }
}