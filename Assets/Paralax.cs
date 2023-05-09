using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Transform cam;
    public float relativeMove = .3f;
    public bool Lock = false;

    void Update()
    {
        if (Lock)
        {
            transform.position = new Vector2(cam.position.x * relativeMove, cam.position.y);
        }
        else
        {
            transform.position = new Vector2(cam.position.x * relativeMove, cam.position.y * relativeMove);
        }
    }
}
