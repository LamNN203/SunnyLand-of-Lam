using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimer : Enemy
{
    public Collider2D coll;
    public float JumpHeight;
    public LayerMask ground;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("jump", false);
        }
    }

    public void Jump()
    {
        rg.velocity = new Vector2(0, JumpHeight);
        anim.SetBool("jump", true);
    }
}
