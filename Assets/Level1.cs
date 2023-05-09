using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public void CLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void CLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void CLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void ChoseLv()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Quitt()
    {
        Application.Quit();
    }
}
