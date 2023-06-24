using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //FSM
    public enum State { idle, running, jumping, falling, hurt, doubleJump }
    public State state = State.idle;

    //(Start) variable
    public Transform pos;
    public Rigidbody2D rb;
    public Animator anim;
    public Collider2D coll;
    public SpawnCoins Spw;
    public SpawnHealth SpwH;
    public GameOverScreen GOV;
    public float OriginPointX;
    public float OriginPointY;
    public Level1 Esc;
    public LevelTransform nextLV;
    public Findplayer UIIndex;
    Playercontrol control;
    

    //Inspector variable
    public float Jump;
    public float DbJump;
    public bool doubleJump;
    public float Runspeed;
    public int Coins = 0;
    public LayerMask ground;
    public float Hurtforce;
    public int Health;
    private int ps; //Points Set
    public float hDirection;
    public float yDirection = 0 ;

    private void Awake()
    {
        GOV = FindObjectOfType<GameOverScreen>();


        control = new Playercontrol();
        control.Enable();

    }
    void Start()
    {
        UIIndex = FindObjectOfType<Findplayer>();
        nextLV = FindObjectOfType<LevelTransform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        UIIndex.HealthText.text = Health.ToString();
        OriginPointX = transform.position.x;
        OriginPointY = transform.position.y;

    }
    void Update()
    {
        if (state != State.hurt)
        {
            Movecontrol();
        }
        Animation();
        anim.SetInteger("state", (int)state);
    }

    // thu thap vat pham
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // an vat pham
        if (collision.tag == "collectable")
        {            
            Destroy(collision.gameObject);
            ScoreCollect mc = collision.gameObject.GetComponent<ScoreCollect>();
            ps = mc.Score;
            Coins += ps; // Cong diem khi an vat pham
            UIIndex.CoinText.text = Coins.ToString();
        }
        //va cham voi QuestionBox
        if (collision.gameObject.tag == "QBox" && state == State.jumping)
        {

            QuestionBox qbox = collision.gameObject.GetComponent<QuestionBox>();

            //nay hop
            qbox.bounce();
            BounceOff();
            //hoat anh
            qbox.hitBox();
            //ra xu vs cong xu
            Spw.SpawnCoin();
            Coins += 1;
            UIIndex.CoinText.text = Coins.ToString();
        }
        //va cham voi HealthBox
        if (collision.gameObject.tag == "HBox" && state == State.jumping)
        {

            HealthBox Hbox = collision.gameObject.GetComponent<HealthBox>();

            //nay hop
            Hbox.bounce();
            BounceOff();
            //hoat anh
            Hbox.hitBox();
            //spawn binh mau
            SpwH.SpwnHealth();
        }
        //roi chet
        if (collision.gameObject.tag == "DeathFall")
        {
            GOV.GameOverS();
           gameObject.SetActive(false);
        }
        //het game
        if (collision.gameObject.tag == "ENDGAME")
        {
            GOV.GameOverS();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //va cham vs enemy co 1 HP
        if (other.gameObject.tag == "Enermy")
        {

            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            
            if (state == State.falling)
            {
                enemy.JumpedOn();
                Jumping();
                Coins += enemy.Score; // Cong diem khi an quai
                UIIndex.CoinText.text = Coins.ToString();
            }
            //hoat anh bi thuong
            else
            {
                //hoat anh hurt
                state = State.hurt;
                HealthCount();
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-Hurtforce, rb.velocity.y + 2);
                }
                if (other.gameObject.transform.position.x < transform.position.x)
                {
                    rb.velocity = new Vector2(Hurtforce, rb.velocity.y + 2);
                }
            }
        }

        // va cham voi enemy co HP 
        if (other.gameObject.tag == "BigEnemy")
        {

            EnemyBehavior enemy = other.gameObject.GetComponent<EnemyBehavior>();
            if (state == State.falling)
            {
                enemy.TakeHit(1);
                Jumping();
                Coins += enemy.Score; // Cong diem khi danh quai
                UIIndex.CoinText.text = Coins.ToString();
            }
            //hoat anh bi thuong
            else
            {
                //hoat anh hurt
                state = State.hurt;
                HealthCount();
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-Hurtforce, rb.velocity.y + 2);
                }
                if (other.gameObject.transform.position.x < transform.position.x)
                {
                    rb.velocity = new Vector2(Hurtforce, rb.velocity.y + 2);
                }
            }
        }
            //va cham voi gai
        if (other.gameObject.tag == "Spike")
        {
            state = State.hurt;
            HealthCount();
            if (other.gameObject.transform.position.y > transform.position.y)
            {
                rb.velocity = new Vector2(Hurtforce, -4);
            }
            if (other.gameObject.transform.position.y < transform.position.y)
            {
                rb.velocity = new Vector2(Hurtforce, 10);
            }
        }
        // thu thap healthPotion
        if (other.gameObject.tag == "HealthPotion")
        {
            Destroy(other.gameObject);
            Health += 1;
            UIIndex.HealthText.text = Health.ToString();
        }
        //va cham cong chuyen man
        if(other.gameObject.tag == "lvTransform")
        {

            nextLV.Complete();
        }
    }

    private void HealthCount()
    {
        //tru mau
        Health -= 1;
        UIIndex.HealthText.text = Health.ToString();
        //reset man
        if (Health <= 0)
        {
            GOV.GameOverS();
            gameObject.SetActive(false);
        }
    }

    //di chuyen nhan vat
    public void Movecontrol()
    {
        control.land.move.performed += ctx =>
        {
            hDirection = ctx.ReadValue<float>();
        };
        control.land.Jump.performed += cts =>
        {
            yDirection = cts.ReadValue<float>();
        };
        //Moving left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-Runspeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        //Moving Right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(Runspeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        //Jumping
         if (coll.IsTouchingLayers(ground) && yDirection > 0)
        {
            doubleJump = false;
        }
         if (yDirection > 0)
        {
            if ( coll.IsTouchingLayers(ground) || doubleJump)
            Jumping();
            doubleJump = !doubleJump ;
        }
        //esc game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc.BackToMenu();
        }
    }
    
    //hoat anh
    void Animation()
    {
        //hoat anh roi
        if (state == State.jumping)
        {
            if (rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        //hoat anh cham dat
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        //hoat anh bi hurt
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < 1.8f)
            {
                state = State.idle;
            }
        }
        //hoat anh chay
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        //hoat anh idle
        else
        {
            state = State.idle;
        }
    }

    //Jump Controll
    void Jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, Jump);
        state = State.jumping;
    }

    //Bounce off
    void BounceOff()
    {
        rb.velocity = new Vector2(rb.velocity.x, -7);
        state = State.falling;
    }


}