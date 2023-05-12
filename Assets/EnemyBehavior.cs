using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int hitpoints;
    public int Maxhitpoins = 3 ;
    public HealthBar healthctr;
    protected Animator anim;
    protected Rigidbody2D rg;
    public Enemy a;
    public int Score;


    private void Start()
    {
        hitpoints = Maxhitpoins;
        healthctr.SetHealth(hitpoints, Maxhitpoins);
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }

    public void TakeHit (int damage)
    {
        hitpoints -= damage; // Tru mau
        healthctr.SetHealth(hitpoints, Maxhitpoins);
        
        if (hitpoints <= 0)
        {
            a.JumpedOn();
        }
    }
}
