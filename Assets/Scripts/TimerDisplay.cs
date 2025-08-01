using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public TMP_Text timerText;
    bool isInit = false;
    private void OnEnable()
    {
        if ( !isInit)
        {
            isInit = true;
            TimerManager.OnValueChange += Tick;
        }
    }
    private void OnDisable()
    {
        if (isInit)
        {
            isInit = false;
            TimerManager.OnValueChange -= Tick;
        }
    }
    private void OnDestroy()
    {
        if (isInit)
        {
            isInit = false;
            TimerManager.OnValueChange -= Tick;
        }
    }
    void Tick()
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
