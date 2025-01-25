using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}
