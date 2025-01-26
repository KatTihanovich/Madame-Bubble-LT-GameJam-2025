using UnityEngine;

public class PauseMusicScript : MonoBehaviour
{
    public void SoundControl(){
        if(AudioListener.pause == true){
            AudioListener.pause = false;
        } else {
            AudioListener.pause = true;
        }
    }
}
