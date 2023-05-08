using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnCoins : MonoBehaviour
{
    public GameObject Qboxcoins;
    
    void Start()
    {
    }

    public void SpawnCoin()
    {
        Instantiate(Qboxcoins, transform.position, transform.rotation);
        
    }
    void Update()
    {
        
    }
}
