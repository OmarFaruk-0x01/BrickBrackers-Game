using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
    public Transform Player, Ball;
    void Start()
    {

        topWall.size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f,0f)).x, 1f);
        topWall.transform.position = new Vector2(0f, Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + .5f);


        bottomWall.size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.transform.position = new Vector2(0f, Camera.main.ScreenToWorldPoint(new Vector3(0f,0f, 0f)).y -.5f);


        rightWall.size = new Vector2(1f,Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + .5f, 0f);


        leftWall.size = new Vector2(1f, Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - .5f, 0f);


        Player.position = new Vector2(0f, Camera.main.ScreenToWorldPoint(new Vector3(0f, 150f, 0f)).y );
        Ball.position = new Vector2(0f, Camera.main.ScreenToWorldPoint(new Vector3(0f, 190f, 0f)).y);



       // Blocks.transform.BroadcastMessage("Resize");
    }

    // Update is called once per frame

}
