using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    private TMP_Text timerText;

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        if (TimerManager.instance != null)
        {
            float time = TimerManager.instance.GetPlayTime();
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}
