using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dec_Ball_Size : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform Ball;
    Transform newBall;
    void OnTriggerEnter2D(Collider2D col)
    {
   

        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.BallSizeX = .15f;
            GameManager.BallSizeY = .15f;
        }
    }
}
