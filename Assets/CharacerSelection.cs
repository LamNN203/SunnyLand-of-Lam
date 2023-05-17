using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacerSelection : MonoBehaviour
{
    private GameObject[] characterList;
    public int Index;

    public void Start()
    {
        // gán key cho từng skin
        Index = PlayerPrefs.GetInt("characterSelected");

        characterList = new GameObject[transform.childCount];

        for(int i = 0; i <transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }

        // load skin khi bắt đầu màn chơi
        if(characterList[Index]) 
        {
            characterList[Index].SetActive(true);
        }
    }

    public void Update()
    {

    }

    public void left() // Chuyển nhân vật
    {
        characterList[Index].SetActive(false);

        Index--;
        if(Index < 0)
        {
            Index = characterList.Length - 1;
        }
        characterList[Index].SetActive(true);
    }

    public void right()
    {
        characterList[Index].SetActive(false);
        Index++;
        if (Index == characterList.Length)
        {
            Index = 0;
        }
        characterList[Index].SetActive(true);
    }// Chuyển nhân vật

    public void confirm()
    {
        PlayerPrefs.SetInt("characterSelected", Index);
        SceneManager.LoadScene("Level1");
    }// Save nhân vật đã chọn & vào màn chơi
}
