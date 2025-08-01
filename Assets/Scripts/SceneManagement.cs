using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;
    public GameObject finishScreen;
    public ScoreUploader uploader;

    private bool redAtDoor = false;
    private bool blueAtDoor = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void setPlayerAtDoor(string playerColor, bool atDoor)
    {
        if (playerColor == "Red")
        {
            redAtDoor = atDoor;
        }
        else if (playerColor == "Blue")
        {
            blueAtDoor = atDoor;
        }
    }
    public void loadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("AdQuesScore", PlayerPrefs.GetInt("AdQuesLevelScore", 0));
        PlayerPrefs.Save();
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("AdQuesScore", 0);
        PlayerPrefs.SetInt("AdQuesLevelScore", 0);
        TimerManager.instance.ResetTimer();
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (redAtDoor && blueAtDoor)
        {
            TimerManager.instance.StopTimer();
            finishScreen.SetActive(true);
            PlayerInfoManager.instance.team.score = PlayerPrefs.GetInt("AdQuesScore", 0);
            PlayerInfoManager.instance.team.timeCount = TimerManager.instance.GetPlayTime();
            redAtDoor = false;
            blueAtDoor = false;
            uploader.UploadScore(PlayerInfoManager.instance.team.player1.name, PlayerInfoManager.instance.team.player1.email, PlayerInfoManager.instance.team.player2.name, PlayerInfoManager.instance.team.player2.email, PlayerInfoManager.instance.team.score, PlayerInfoManager.instance.team.timeCount);
        }
    }
   
    #region Cheat
    public void WinGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            setPlayerAtDoor("Red", true);
            setPlayerAtDoor("Blue", true);
        }
        else
        {
            SceneManager.LoadScene(5);
        }
    }
    #endregion
}
