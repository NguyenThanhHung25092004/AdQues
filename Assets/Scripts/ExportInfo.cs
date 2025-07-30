using System.Security.Cryptography;
using UnityEngine;

public class ExportInfo : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/Results.csv";
        if (!System.IO.File.Exists(filePath))
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
            {
                writer.WriteLine("Name, Email, Score, Time");
            }
        }
    }
    public void exportFinalResults()
    {
        var p1 = PlayerInfoManager.instance.team.player1;
        var p2 = PlayerInfoManager.instance.team.player2;
        int score = PlayerInfoManager.instance.team.score;

        string line1 = $"{p1.name},{p1.email},{score}, {TimerManager.instance.GetPlayTime()}";
        string line2 = $"{p2.name},{p2.email},{score}, {TimerManager.instance.GetPlayTime()}";

        saveLine(line1);
        saveLine(line2);

        PlayerInfoManager.instance.resetAll();
        TimerManager.instance.ResetTimer();
    }

    private void saveLine(string line)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
        {
            writer.WriteLine(line);
        }
    }
}
