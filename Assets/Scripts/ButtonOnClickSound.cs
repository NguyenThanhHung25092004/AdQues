using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClickSound : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => clickSound());
    }

    private void clickSound()
    {
        SoundLibrary.instance.PlaySound("Click");
    }

    
}
