using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            SceneManagement.instance.setPlayerAtDoor("Blue", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            SceneManagement.instance.setPlayerAtDoor("Blue", false);
        }
    }
}
