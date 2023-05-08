using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bettle : Enemy
{
    public Collider2D coll;
    public LayerMask ground;
    public float StaticPoint;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        StaticPoint = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < StaticPoint - 1)
        {
            rg.velocity = new Vector2(0, 2);
        }
    }
}
