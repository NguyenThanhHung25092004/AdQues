using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;
    public Vector2 lastCheckPoint;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

}
