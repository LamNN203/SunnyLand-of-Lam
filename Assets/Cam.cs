using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float FollowSpeed;
    public float yOffset;
    public PlayerController target;
    public Transform thiscam;

    void Start()
    {
        target = FindObjectOfType<PlayerController>();
        thiscam = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(thiscam.position.x+5, thiscam.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
