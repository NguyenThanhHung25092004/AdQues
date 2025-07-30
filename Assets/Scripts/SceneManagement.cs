using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;
    public GameObject finishScreen;
    [SerializeField] private ExportInfo exportInfo;

    private bool redAtDoor = false;
    private bool blueAtDoor = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        exportInfo = FindFirstObjectByType<ExportInfo>();
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
            PlayerInfoManager.instance.team.timeEnd = TimerManager.instance.getTimeNow();
            exportInfo.exportFinalResults();
            redAtDoor = false;
            blueAtDoor = false;
        }
    }
}
