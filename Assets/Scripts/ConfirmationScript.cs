using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmationScript : MonoBehaviour
{
    public GameObject confirmationUI;

    public void Resume(){
        confirmationUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause(){
        confirmationUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
