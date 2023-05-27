using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransform : MonoBehaviour
{
    public playGameScript info;
    public int ind;
    void Start()
    {
        info = FindObjectOfType<playGameScript>();
    }
    void Update()
    {
    }
    public void Complete()
    {
        info.playGamePressed(ind);
    }
}
