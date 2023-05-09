using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject GameOver;
    void Start()
    {

    }
    public void GameOverS()
    {
        GameOver.SetActive(true);
    }

}
