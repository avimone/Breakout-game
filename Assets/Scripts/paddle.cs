using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    public static paddle instance;
    #region fields
    private Rigidbody2D myRigidbody2D = default;
    private PolygonCollider2D myBoxCollider2D = default;
    private float paddleColliderHalfWidth = 0;

    private const string Horizontal = "Horizontal";
    private const string BallTag = "Ball";
    private const float BounceAngleHalfRange = Mathf.Deg2Rad * 60;
    [SerializeField]
    float xmin = 8.357969f;
    [SerializeField]
    float xmax = -8.167648f;

    Vector3 temp;

    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       
    }
    private void Start()
    {
        xmin = 9.7f;
        xmax = -10.3f;
        // cache components
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myBoxCollider2D = GetComponent<PolygonCollider2D>();
      //  sizeup();
        // stores half the size of collider for clamping 
     //   paddleColliderHalfWidth = myBoxCollider2D.size.x / 2;
    }

    private void Update()
    {
       // ClampPaddle();
       if(transform.position.x > xmin)
        {
           Vector2 newpos = new Vector2(xmin,transform.position.y);
            transform.position = newpos;
        }
        if (transform.position.x < xmax)
        {
            Vector2 newpos = new Vector2(xmax, transform.position.y);
            transform.position = newpos;
        }
    }

    private void FixedUpdate()
    {
        // move the paddle using Rigidbody2D based on users Horizontal input
        float inputHor = Input.GetAxis(Horizontal);
        if (inputHor != 0)
        {
            Vector2 input = new Vector2(inputHor, 0) * 10f;
            myRigidbody2D.MovePosition(myRigidbody2D.position + input * Time.fixedDeltaTime);
        }
    }

  
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: prevent ball from bouncing off of bottom
        // sets the ball direction based on where it hit the paddle
        //  BallHitPaddlePos(collision);
        audioManager.Play(Soundname.paddlehits);
    
    }
    public void sizeup()
    {
         temp = new Vector3(0.1f, 0f,0f);
        transform.localScale += temp;
      //  xmin -= 0.3f;
      //  xmax += 0.3f;

      
    }
    public void sizedown()
    {
        if (transform.localScale.x >= 0.2f)
        {
            temp = new Vector3(0.1f, 0f, 0f);
            transform.localScale -= temp;
        }
      //  xmin += 0.5f;
      //  xmax += -0.5f;


    }
    private void BallHitPaddlePos(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            // detect if the ball hit top of the paddle
            bool ballHitTop = ball.transform.position.y > transform.position.y - 0.05f;
            if (ballHitTop)
            {
                float ballOffsetFromPaddle = (transform.position.x - ball.transform.position.x) / paddleColliderHalfWidth;
                float angleOffset = ballOffsetFromPaddle * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                ball.setDirection(direction);
            }
        }
    }
}
