using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogyAI : Enemy
{
    public Collider2D coll;
    // frog move
    public float JumpForce;
    public float JumpHeight;
    public LayerMask ground;
    public bool Facingleft = true;
    // Moving Limit
    private float OriginPoint;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        OriginPoint = transform.position.x;
    }
    void Update()
    {
        // hoat anh nhay va cham dat cua ech
        if (anim.GetBool("jumping"))
        {
            if (rg.velocity.y < 0.1f)
            {
                anim.SetBool("falling", true);
                anim.SetBool("jumping", false);
            }
        }
        if (coll.IsTouchingLayers(ground) && anim.GetBool("falling"))
        {
            anim.SetBool("falling", false);
        }
    }
    private void Move()
    {
        if (Facingleft)
        {
            if (transform.position.x > OriginPoint - 4.5)
            {
                //doi huong 
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                //nhay khi cham dat
                if (coll.IsTouchingLayers(ground))
                {
                    rg.velocity = new Vector2(-JumpForce, JumpHeight);
                    anim.SetBool("jumping", true);
                }
            }
            else
            {
                Facingleft = false;
            }
        }

        else
        {
            if (transform.position.x < OriginPoint + 4.5)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rg.velocity = new Vector2(JumpForce, JumpHeight);
                    anim.SetBool("jumping", true);
                }
            }
            else
                Facingleft = true;
        }
    }

}