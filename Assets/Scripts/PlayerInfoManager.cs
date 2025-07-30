using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public static PlayerInfoManager instance;

    [System.Serializable]
    public class InfoTeam
    {
        public InfoUser player1;
        public InfoUser player2;
        public int score;
        public string timeEnd;
        public float timeCount;
    }

    public InfoTeam team = new InfoTeam();

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
        team = new InfoTeam();
    }

}
