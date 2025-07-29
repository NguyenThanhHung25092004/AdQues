using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            Debug.Log("Checkpoint");
            RespawnManager.instance.lastCheckPoint = transform.position;
        }
        
    }
}
