using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playGameScript : MonoBehaviour
{
    public static playGameScript pgs;
    public string[] url, sceneNames;
    public int index;

    static AssetBundle assetBundle;
    WWW www;
    private void Awake()
    {
        if (pgs == null)
        {
            pgs = this;
        }
    }
    private void Start()
    { 
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

}