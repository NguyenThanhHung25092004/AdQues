using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FontSizeChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform imageRect;
    private float normalScale = 1f;
    [SerializeField] private float hoverScale = 1.08f;

    void Awake()
    {

        if(imageRect == null)
        {
            imageRect = GetComponent<RectTransform>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageRect.localScale = Vector3.one * hoverScale;
        SoundLibrary.instance.PlaySound("Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageRect.localScale = Vector3.one * normalScale;
    }
}
