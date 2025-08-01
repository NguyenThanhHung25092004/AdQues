using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if(GameManager.Instance == null)
        {
            Instance = this;
            Application.targetFrameRate = 60;
            PlayerPrefs.SetInt("AdQuesScore", 0);
            PlayerPrefs.SetInt("AdQuesLevelScore", 0);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        
    }
    public void PlayLevel1()
    {
        StartCoroutine(WaitingLoadScene());
    }
    IEnumerator WaitingLoadScene()
    {
        var load = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!load.isDone)
        {
            yield return null;
        }
        TimerManager.instance.StartTimer();
    }
}
