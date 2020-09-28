using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;
    Rigidbody2D rbd = default;
    bool moving = false;
    float moveAngle = 20f;
    bool ballMoved = false;
    public Transform paddle;
    GameObject childpaddle;
    public float maxspeed = 10;
    Levelbuild obj;
    bool firstTime;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

        firstTime = true;
        rbd = GetComponent<Rigidbody2D>();    
    }
   public void setDirection(Vector2 dir)
    {
        rbd.velocity = rbd.velocity.magnitude * dir; 
    }
    void moveBall()
    {

      
            if (!ballMoved)
            {
                Vector2 velocity = new Vector2(Mathf.Cos(moveAngle), Mathf.Sin(moveAngle));
                rbd.AddForce(velocity * 250);
                ballMoved = true;

            }
        else
        {
            clamspeed();
            if(rbd.velocity.magnitude < 3)
            {
                //  Vector2 velocity = new Vector2(Mathf.Cos(moveAngle), Mathf.Sin(moveAngle));
                // rbd.AddForce(velocity * 250);
                rbd.velocity = Vector2.ClampMagnitude(rbd.velocity, maxspeed);
            }
        }
        

    }

    private void clamspeed()
    {
        rbd.velocity = Vector2.ClampMagnitude(rbd.velocity,maxspeed);
    }

    void destroyBall()
    {
        if (transform.position.y < (ScreenUtils.ScreenBottom - 5))
        {
            //HUD.BallLeftScreen();
            //  ballSpawner.SpawnNewBall();
           
          //  Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
      
        if(Input.GetKeyDown(KeyCode.Space) && firstTime == true)
        {
            moving = true;
            ballMoved = false;
            firstTime = false;
        }
        if (!moving)
        {
            Vector2 tempos = Levelbuild.pos;
            tempos.y += 0.5f;
            transform.position = tempos;
        }
        else
        {
            moveBall();
          //  destroyBall();
        }
    }
    public int Lifes()
    {
        return Levelbuild.instance.lives;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("gameover"))
        {

            //    Levelbuild.instance.decLife();
            Destroy(gameObject);
            Levelbuild.instance.balldied();
           // moving = false;
           // rbd.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            Vector2 velocity = new Vector2(Mathf.Cos(moveAngle), Mathf.Sin(moveAngle));
            rbd.AddForce(velocity * 250);
        }
    }
}
