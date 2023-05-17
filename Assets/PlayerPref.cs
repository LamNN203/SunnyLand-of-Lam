using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    public int level;
    public int TempHighscore;
    public PlayerController temps;


    public void Start()
    {
        // load diem cao tam thoi
        TempHighscore = LoadHighscore(level); 

        Debug.Log("Current high Score :" + TempHighscore);
    }

    public void Update()
    {
        upscore();// cập nhật điểm cao
    }
    public void SaveHighscore(int level, int score)
    {
        PlayerPrefs.SetInt("highscore_level_" + level, score);
        Debug.Log("New high Score :" + temps.Coins);
    }

    public int LoadHighscore(int level)//Load điểm theo màn chơi
    {
        return PlayerPrefs.GetInt("highscore_level_" + level, 0);
    }

    public void upscore()
    {
        if(temps.Coins > TempHighscore)
        {
            SaveHighscore(level, temps.Coins);
        }
    }

}
