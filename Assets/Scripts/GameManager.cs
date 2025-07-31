using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        PlayerPrefs.SetInt("AdQuesScore", 0);
        PlayerPrefs.SetInt("AdQuesLevelScore", 0);
        DontDestroyOnLoad(gameObject);
    }
}
