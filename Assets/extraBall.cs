using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraBall : MonoBehaviour
{
    Rigidbody2D rbd = default;
    bool moving = false;
    float moveAngle = 20f;
    bool ballMoved = false;
    public Transform paddle;
    GameObject childpaddle;
    public float maxspeed = 10;
    Levelbuild obj;

    // Start is called before the first frame update
  
    void Start()
    {


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
        }


    }

    private void clamspeed()
    {
        rbd.velocity = Vector2.ClampMagnitude(rbd.velocity, maxspeed);
    }

    void destroyBall()
    {
        if (transform.position.y < (ScreenUtils.ScreenBottom - 5))
        {
            //HUD.BallLeftScreen();
            //  ballSpawner.SpawnNewBall();

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
            ballMoved = false;
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
            destroyBall();
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gameover"))
        {

            Destroy(gameObject);

          
        }
    }
}
