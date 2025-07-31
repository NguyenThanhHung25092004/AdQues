using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    public bool isPaused {  get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public void pauseGame()
    {
        if(!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
    }

    public void resumeGame()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;

        }
    }
}
