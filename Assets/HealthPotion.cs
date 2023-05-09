using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private Rigidbody2D rg;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(3.5f, 5f);
    }

}
