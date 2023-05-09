using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsInQbox : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 5);
    }
    void EndCoins()
    {
        Destroy(this.gameObject);
    }
}
