using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FontSizeChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TMP_Text text;
    private float normalFontSize = 64f;
    public float hoverFontSize = 75f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(text == null)
        {
            text = GetComponentInChildren<TMP_Text>();
        }
        text.fontSize = normalFontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.fontSize = hoverFontSize;
        SoundLibrary.instance.PlaySound("Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.fontSize = normalFontSize;
    }
}
