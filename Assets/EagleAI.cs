using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleAI : Enemy
{
    public Collider2D coll;
    public LayerMask ground;
    public float RunForce;
    public bool Facingleft = true;
    public float OriginPoint;
    // AI that enemy chasing player 
    public GameObject Player;
    public float speed;
    private float distance;
    public float distanceBetween;
    private float a; // Player Position x
    private float b; // Distance between Player vs enemy


    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        OriginPoint = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateDistance();// update khoang cach cua enemy voi player

        if (b < distanceBetween)
        {
            AI();
        }
        else if (b > distanceBetween)
        {
            Move();
        }
    }
    // enemy di chuyển qua lại trong 1 điểm
    private void Move()
    {
        if (Facingleft)
        {
            if (transform.position.x > OriginPoint - 4.5f)
            {
                //doi huong 
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
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
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                //chay
                rg.velocity = new Vector2(RunForce, 0);
            }
            else
                Facingleft = true;
        }
    }

    // AI enemy đuổi theo người chơi
    private void AI()
    {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
      
            
       
            if (transform.position.x >= a)
            {
            //doi huong              
            transform.localScale = new Vector3(1, 1);
            }
            else
            {
            transform.localScale = new Vector3(-1, 1);
            }

    }

    private void UpdateDistance()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();

        a = Player.transform.position.x;
        b = distance;
    }
}

