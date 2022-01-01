using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

public class VictorySave : MonoBehaviour
{
    public TextMeshProUGUI TimerVic;
    private HighScore savedScored; 

    private void Start()
    {
        TimerVic.text = Timer.GetTime();

        Debug.Log(Application.persistentDataPath);

        if (!File.Exists(Application.persistentDataPath + "/highscore.save"))
        {
            savedScored = new HighScore();
            savedScored.highScore = TimerVic.text;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/highscore.save");
            bf.Serialize(file, savedScored);
            file.Close();
        }
        else
        {
            HighScore other;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscore.save", FileMode.Open);
            other = (HighScore)bf.Deserialize(file);
            file.Close();

            if (string.Compare(TimerVic.text,other.highScore) == -1)
            {
                savedScored = new HighScore();
                savedScored.highScore = TimerVic.text;
                file = File.Open(Application.persistentDataPath + "/highscore.save", FileMode.Open);
                bf.Serialize(file, savedScored);
                file.Close();
            }    
        }
    }
}
