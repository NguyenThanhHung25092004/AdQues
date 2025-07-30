using UnityEngine;

public class MusicButtonLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StopSound()
    {
        SoundLibrary.stopMusic();
    }

    public void PlaySound()
    {
        SoundLibrary.playMusic();
    }
}
