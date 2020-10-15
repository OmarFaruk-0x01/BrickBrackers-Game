using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inc_Ball_Size : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform Ball;
    Transform newBall;
    void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log("Power TOuched: " + col.name);

        if (col.tag == "Ball")
        {
            transform.GetComponent<Rigidbody2D>().gravityScale = .5f;
            transform.gameObject.SetActive(true);
            //  transform.GetComponent<SpriteRenderer>().color = new Color(transform.GetComponent<SpriteRenderer>().color.r, transform.GetComponent<SpriteRenderer>().color.g, transform.GetComponent<SpriteRenderer>().color.b, 1f);
    

        }

        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.BallSizeX = GameManager.BallBaseSizeX + .4f;
            GameManager.BallSizeY = GameManager.BallBaseSizeY + .4f;
        }
    }
}
