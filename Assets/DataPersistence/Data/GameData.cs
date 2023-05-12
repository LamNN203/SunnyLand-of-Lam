using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int CoinsNumber;
    public int Lv1High;
    public int Lv2High;
    public int Lv3High;
    public GameData()
    {
        this.CoinsNumber = 0;
        this.Lv1High = 0;
        this.Lv2High = 0;
        this.Lv3High = 0;
}
}
