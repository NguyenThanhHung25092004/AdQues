using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class ScoreUploader : MonoBehaviour
{
    public string hostAddress = "https://we.adtrue.com/AdQues/adq.php";

    public void Tester()
    {
        for (int i = 0; i < 1000; i++)
        {
            UploadScore("henry" + i, "henry@example.com" + i, "teammate" + i, "mate@example.com" + i, Random.Range(0, 16), Random.Range(100, 200));
        }

        StartCoroutine(EDelay());
    }
    IEnumerator EDelay()
    {
        int count = 0;
        while (count < 10)
        {
            yield return new WaitForSeconds(1);
            UploadScore("henry", "henry@example.com", "teammate", "mate@example.com", Random.Range(0, 16), Random.Range(100, 200));
            count++;
        }
    }
    public void UploadScore(string name1, string email1, string name2, string email2, int score, float timecount)
    {
        ScoreData tmp = new()
        {
            name1 = name1,
            email1 = email1,
            name2 = name2,
            email2 = email2,
            score = score,
            timecount = timecount
        };
        StartCoroutine(PostScore(tmp));
    }

    IEnumerator PostScore(ScoreData userInfo)
    {
        string jsonData = JsonUtility.ToJson(userInfo);
        Debug.Log("📤 JSON gửi:\n" + jsonData);

        UnityWebRequest request = new UnityWebRequest(hostAddress, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Score submitted!");
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }
    [System.Serializable]
    public class ScoreData
    {
        public string name1;
        public string email1;
        public string name2;
        public string email2;
        public int score;
        public float timecount;
    }


}