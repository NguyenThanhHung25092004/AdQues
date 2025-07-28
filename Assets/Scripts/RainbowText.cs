using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class RainbowText : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float speed = 1f;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        float loop = Mathf.PingPong(speed * Time.time, 1f);
        text.color = Color.HSVToRGB(loop, 1f, 1f);

    }
}
