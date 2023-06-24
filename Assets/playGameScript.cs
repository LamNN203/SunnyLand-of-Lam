using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate{OnClick(param);});
    }
}
public class playGameScript : MonoBehaviour
{
    public static playGameScript pgs;
    public string[] url, sceneNames, all;
    private int a = 0, IndexHigh = 0, lvNum = 0;
    public string target = "D:/Before 20 4/AssetBundle/StandaloneWindows";
    public GameObject LVbar;
    public Transform container;
    static AssetBundle assetBundle;
    public Text labelText;
    public Text HighScore;
    public Button prefab;
    public PlayerPref loadscore;
    WWW www;

    private void Start()
    {
        url = Directory.GetFiles(target, "level?");
        foreach (string adc in url)
        {
            Debug.Log(adc);
            sceneNames[a] = Path.GetFileNameWithoutExtension(adc);
            a++;
        }
        spawns();
    }

    public void playGamePressed(int i)
    {
        StartCoroutine(s(i));
    }
    IEnumerator s(int i)
    {
        if (!assetBundle)
        {
            using (www = new WWW(url[i]))
            {
                yield return www;
                if (!string.IsNullOrEmpty(www.error))
                {
                    print(www.error);
                    yield break;
                }
                assetBundle = www.assetBundle;
            }
        }
        string[] scenes = assetBundle.GetAllScenePaths();

        foreach (string s in scenes)
        {
            print(Path.GetFileNameWithoutExtension(s));
            print(sceneNames[i]);

            if (Path.GetFileNameWithoutExtension(s) == sceneNames[i])
            {
                loadScene(Path.GetFileNameWithoutExtension(s));
            }
        }
    }


    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void spawns()
    {
        foreach(string names in url)
        {
            labelText.text = Path.GetFileNameWithoutExtension(names);
            HighScore.text = loadscore.LoadHighscore(IndexHigh).ToString();

            var clone = Instantiate(prefab.gameObject) as GameObject;

            clone.GetComponent<Button>().AddEventListener(lvNum, playGamePressed);
            clone.SetActive(true);
            clone.transform.SetParent(container);

            IndexHigh++;
        }

    }

}