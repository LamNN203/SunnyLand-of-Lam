using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject GameOver;
    private void Awake()
    {
        
    }
    void Start()
    {
        GameOver.SetActive(false);

    }
    public void GameOverS()
    {
        GameOver.SetActive(true);
    }

}
