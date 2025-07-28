using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public static PlayerInfoManager instance;

    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public string email;
        public int score;
    }

    public PlayerData player1 = new PlayerData();
    public PlayerData player2 = new PlayerData();

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

    public void resetAll()
    {
        player1 = new PlayerData();
        player2 = new PlayerData();
    }
}
