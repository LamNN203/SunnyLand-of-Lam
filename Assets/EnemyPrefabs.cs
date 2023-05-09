using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rg;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }
    public void JumpedOn()
    {
        anim.SetTrigger("death");
        rg.velocity = new Vector2(0, 0);
    }
    public void Death()
    {
        Destroy(this.gameObject);
    }
}