using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{

    public int High1 ;
    public int High2 ;
    public int High3 ;
    public Text HighSc1;
    public Text HighSc2;
    public Text HighSc3;
    public PlayerPref load ;

    public void Start()
    {
        High1 = load.LoadHighscore(1);
        High2 = load.LoadHighscore(2);
        High3 = load.LoadHighscore(3);
    }
    void Update()
    {
        HighSc1.text = High1.ToString();
        HighSc2.text = High2.ToString();
        HighSc3.text = High3.ToString();
    }

    
}

