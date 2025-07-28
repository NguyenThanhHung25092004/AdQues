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
                writer.WriteLine("Name, Email, Score");
            }
        }
    }
    public void exportFinalResults()
    {
        var p1 = PlayerInfoManager.instance.player1;
        var p2 = PlayerInfoManager.instance.player2;

        string line1 = $"{p1.name},{p1.email},{p1.score}";
        string line2 = $"{p2.name},{p2.email},{p2.score}";

        saveLine(line1);
        saveLine(line2);

        PlayerInfoManager.instance.resetAll();
    }

    private void saveLine(string line)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
        {
            writer.WriteLine(line);
        }
    }
}
