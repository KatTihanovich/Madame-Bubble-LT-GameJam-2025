using UnityEngine;

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
}
