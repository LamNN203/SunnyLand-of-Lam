using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] playerList;
    public int index;
    void Awake()
    {
        index = PlayerPrefs.GetInt("characterSelected");

        Instantiate(playerList[index], transform.position, transform.rotation);
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        Destroy(this.gameObject);
    }
}
