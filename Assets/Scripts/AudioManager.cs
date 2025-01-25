using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] public AudioSource MusicSource;
    [SerializeField] public AudioSource FXSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip background;
    [SerializeField] public AudioClip text;

    // [Header("Volume Settings")]
    // public SoundManager soundManager;

    public static AudioManager instance; 

    private void Awake(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    private void Start(){
        // if (PlayerPrefs.HasKey("musicVolume")){
        //     soundManager.LoadValue();
        // }
        MusicSource.clip = background;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        FXSource.PlayOneShot(clip);
    }

    // public void PlayUI(){
    //     UISource.PlayOneShot(ui);
    // }

    public void SoundControl(){
        if(AudioListener.pause == true){
            AudioListener.pause = false;
        } else {
            AudioListener.pause = true;
        }
    }
}
