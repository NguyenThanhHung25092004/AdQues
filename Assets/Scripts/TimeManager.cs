using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    private float playTime = 0f;
    private bool isRunning = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Update()
    {
        if (isRunning)
        {
            playTime += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        Debug.Log("TimerStarted");
        isRunning = true;
    }

    public void StopTimer()
    {
        Debug.Log("TimeStopped");
        isRunning = false;
    }

    public float GetPlayTime()
    {
        return playTime;
    }

    public void ResetTimer()
    {
        playTime = 0f;
    }

    public string getTimeNow()
    {
        return System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
    }

}
