using UnityEngine;

public class PauseAudioEffect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private AudioLowPassFilter lowPassFilter;
    [SerializeField] private float normalCutoffFrequency = 22000f; 
    [SerializeField] private float pausedCutoffFrequency = 800f;

    private bool isPaused = false;

    void Start()
    {
        // Ensure the low-pass filter is properly assigned
        if (lowPassFilter == null)
        {
            lowPassFilter = audioSource.GetComponent<AudioLowPassFilter>();
            if (lowPassFilter == null)
            {
                Debug.LogError("AudioLowPassFilter not found on the AudioSource.");
                return;
            }
        }

        // Initialize the filter's cutoff frequency
        lowPassFilter.cutoffFrequency = normalCutoffFrequency;
    }


    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Enable the low-pass filter effect (muffled audio)
            lowPassFilter.cutoffFrequency = pausedCutoffFrequency;
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            // Reset to normal audio
            lowPassFilter.cutoffFrequency = normalCutoffFrequency;
            Time.timeScale = 1f; // Resume the game
        }
    }
}
