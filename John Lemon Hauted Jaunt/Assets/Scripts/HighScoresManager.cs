using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour
{
    public Text scoresTable;
    private List<string> highScores;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("HighScores"))
        {
            LoadScores();
        }        
    }

    public void SaveScore(string time)
    {
        string jsonHighScores = PlayerPrefs.GetString("highScores");
        highScores = JsonConvert.DeserializeObject<List<string>>(jsonHighScores);
        highScores.Add(time);
        highScores.Sort();        
        jsonHighScores = JsonConvert.SerializeObject(highScores);
        PlayerPrefs.SetString("highScores", jsonHighScores);
    }

    void LoadScores()
    {
        string jsonHighScores = PlayerPrefs.GetString("highScores");
        highScores = JsonConvert.DeserializeObject<List<string>>(jsonHighScores);
        int scoresToShow = highScores.Count < 5 ? highScores.Count : 5;

        for (int i = 0; i < scoresToShow; i++)
        {
            scoresTable.text += $"\n{i+1}                                         {highScores[i]}";
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
