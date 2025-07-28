using UnityEngine;

public class FallLimitLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        SceneManagement.instance.reloadScene();
    }
}
