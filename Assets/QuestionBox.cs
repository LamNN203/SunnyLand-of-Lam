using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionBox : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rg;
    private Collider2D coll;
    public GameObject box;
    public enum State {idle, hitted };
    public State state = State.idle;

    public float bounceHeight;
    public float staticPoint ;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        staticPoint = transform.position.y - 0.1f;
    }
    public void bounce()
    {
        rg.velocity = new Vector2(0, bounceHeight);
    }

    public void hitBox()
    {
        state = State.hitted;
        anim.SetInteger("state", (int)state);
    }

    public void DestroyBox()
    {
        Destroy(this.gameObject);
    }
    void Update()
    {

        if (transform.position.y < staticPoint)
        {
            rg.velocity = new Vector2(0, 1);
        }
    }   
}
