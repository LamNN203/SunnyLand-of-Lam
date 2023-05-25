using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Findplayer : MonoBehaviour
{
    public Text HealthText;
    public Text CoinText;

    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
       
    }
}
