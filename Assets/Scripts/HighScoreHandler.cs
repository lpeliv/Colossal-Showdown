using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

public class HighScoreHandler : MonoBehaviour
{
    public TextMeshProUGUI time;

    private void Start()
    {
        HighScore highScore;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/highscore.save", FileMode.Open);
        highScore = (HighScore)bf.Deserialize(file);
        file.Close();

        time.text = highScore.highScore;
    }
}
