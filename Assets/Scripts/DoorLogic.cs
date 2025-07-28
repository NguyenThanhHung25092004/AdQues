using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    private bool player1Entered = false;
    private bool player2Entered = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            player1Entered = true;
        } 

        if(collision.gameObject.CompareTag("Player2")) {
            player2Entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            player1Entered = false;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            player2Entered = false;
        }
    }

    private void Update()
    {
        if (player1Entered && player2Entered)
        {
            SceneManagement.instance.loadNextLevel();
        }
    }
}
