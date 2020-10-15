
using UnityEngine;

public class BarMovement : MonoBehaviour
{
    public Rigidbody2D Bar;
    private float speed = 4f;
    private float direction = 1.5f;
    GameObject Ball;

    void MoveLeft()
    {
        Ball = GameObject.FindWithTag("Ball");
        Bar.MovePosition((Vector2)transform.position + (new Vector2(direction * -1, 0f) * speed * Time.deltaTime));
        if (!GameManager.isBallMoving)
        {
            Ball.transform.position = new Vector2(Bar.transform.position.x, Ball.transform.position.y);
            //Ball.GetComponent<Rigidbody2D>().MovePosition((Vector2)Ball.transform.position + (new Vector2(-direction, 0f) * speed * Time.deltaTime));
        }
    }

    void MoveRight()
    {
        Ball = GameObject.FindWithTag("Ball");
        Bar.MovePosition((Vector2)transform.position + (new Vector2(direction, 0f) * speed * Time.deltaTime));
        if (!GameManager.isBallMoving)
        {

            Ball.transform.position = new Vector2(Bar.transform.position.x, Ball.transform.position.y);

            ///Ball.GetComponent<Rigidbody2D>().MovePosition((Vector2)Ball.transform.position + (new Vector2(direction, 0f) * speed * Time.deltaTime));
        }
    }


    void Update()
    {
        Bar = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        Bar.transform.localScale = new Vector2(GameManager.BarSizeX, GameManager.BarSizeY);
    }

    void ResetBar ()
    {
        GameManager.BarSizeX = GameManager.BarBaseSizeX;

    }

    void FixedUpdate()
    {


        if (Input.GetKey("a"))
        {
            MoveLeft();
        }

        if (Input.GetKey("d"))
        {
            MoveRight();
        }


        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);


            if (touchPos.x > 0)
            {
                if (Input.GetTouch(0).position.y < Screen.safeArea.height - 150)
                {
                    MoveRight();
                }
            }
            else if (touchPos.x < 0)
            {
               if ( Input.GetTouch(0).position.y < Screen.safeArea.height - 150)
                {

                    MoveLeft();

                }

            }


        }
    }
}
