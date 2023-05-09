using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnHealth : MonoBehaviour
{
    public GameObject HealthPotion;
    void Start()
    {
    }

    public void SpwnHealth()
    {
        Instantiate(HealthPotion, transform.position, transform.rotation);
    }
    void Update()
    {

    }
}