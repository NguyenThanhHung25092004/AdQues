using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.SceneManagement;
public class MenuManagement : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayLevel1()
    {
        GameManager.Instance.PlayLevel1();
    }
    public void StartTime()
    {
        TimerManager.instance.StartTimer();
    }

    public void BackToLastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
