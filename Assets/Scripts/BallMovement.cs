
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D Ball;
    public Transform BallPrefb;
    public float BallX = 28.1f;
    public float BallY = 23.21f;
    // Start is called before the first frame updat

    
    void GoBall()
    {
        Ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        float Rand = Random.Range(0, 2);
        Ball.transform.parent = null;
        if (Rand < 1f)
        {
           Ball.AddForce (new Vector2(BallX  , BallY));

        }
        else
        {
            Ball.AddForce (new Vector2(BallX * -1,  BallY));

        }

    }



    void Update()
    {
        Ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        Ball.transform.localScale = new Vector2(GameManager.BallSizeX, GameManager.BallSizeY);
    }

    void FixedUpdate()
    {
        if (GameManager.isBallMoving)
        {


            if (Ball.velocity.y >= -1f && Ball.velocity.y <= 0)
            {
                Ball.AddForce(new Vector2(0f, -5f));
            }


            if (Ball.velocity.y >= 0 && Ball.velocity.y <= 1)
            {
                Ball.AddForce(new Vector2(0f, -5f));
            }



            if (Ball.velocity.x >= -1 && Ball.velocity.x <= 0)
            {
                Ball.AddForce(new Vector2(-5f, 0f));
            }


            if (Ball.velocity.x >= -1 && Ball.velocity.x <= 0)
            {
                Ball.AddForce(new Vector2(5f, 0f));
            }
        }

}

 

    void SmallPushBall()
    {
        Ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        Ball.velocity *= -1; 
    }


    void StopBall()
    {
        Ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        Ball.velocity = Vector2.zero;
        GameManager.isBallMoving = false;
    }
    void ResetBall()
    {
        Ball.velocity = Vector2.zero;
        Ball.transform.localScale = new Vector2(GameManager.BallSizeX, GameManager.BallSizeY);
        GameManager.BallHItValue = 1;
        GameManager.BallSizeX = GameManager.BallBaseSizeX;
        GameManager.BallSizeY = GameManager.BallBaseSizeY;
    }

}
