using UnityEngine;
using UnityEngine.UI;

public class NextORBackButtonLogic : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            button.onClick.Invoke();
        }
    }
}
