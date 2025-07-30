using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public QuestionDataBase question;
    public GameObject hiddenArea;
    public bool hasBeenAnswered = false;

    private bool playerInTrigger = false;
    private GameObject currentPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BlockTriggered");
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            playerInTrigger = true;
            currentPlayer = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            currentPlayer = null;
            playerInTrigger = false;
        }
    }

    public bool isPlayerInTrigger(GameObject player)
    {
        return playerInTrigger && currentPlayer == player;
    }

    public void Interact()
    {
        QuestionManager.instance.showQuestion(question, this);
    }
    public void showArea()
    {
        hiddenArea.SetActive(!hiddenArea.activeSelf);
    }

}
