using TMPro;
using UnityEngine;

public class InfoSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField player1Name;
    [SerializeField] private TMP_InputField player1Email;
    [SerializeField] private TMP_InputField player2Name;
    [SerializeField] private TMP_InputField player2Email;

    public void confirmInfo()
    {
        PlayerInfoManager.instance.player1.name = player1Name.text;
        PlayerInfoManager.instance.player1.email = player1Email.text;
        PlayerInfoManager.instance.player2.name = player2Name.text;
        PlayerInfoManager.instance.player2.email = player2Email.text;
    }
}
