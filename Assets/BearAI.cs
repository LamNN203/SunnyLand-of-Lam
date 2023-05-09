using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAI : Enemy
{
    public LayerMask ground;
    public bool Facingleft = true;
    public Collider2D coll;
    private float OriginPoint;
    public float RunForce;
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        OriginPoint = transform.position.x;
    }

    void Update()
    {
        Move();
    }
    
    //Bear moving
    private void Move()
    {
        if (Facingleft)
        {
            if (transform.position.x > OriginPoint - 4.5f)
            {
                //doi huong 
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                //chay
                rg.velocity = new Vector2(-RunForce, 0);
            }
            else
            {
                Facingleft = false;
            }
        }

        else
        {
            if (transform.position.x < OriginPoint + 4.5f)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                //chay
                rg.velocity = new Vector2(RunForce, 0);
            }
            else
                Facingleft = true;
        }
    }
}
