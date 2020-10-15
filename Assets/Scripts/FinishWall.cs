using UnityEngine;


public class FinishWall : MonoBehaviour
{
    public Transform Player;


    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D collinfo)
    {
        if (collinfo.tag == "Ball")
        {
            Player = GameObject.FindWithTag("Player").transform;
            Player.transform.position.Set(0f, Player.transform.position.y, 0f);
            collinfo.gameObject.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y  + .4f);
            collinfo.gameObject.SendMessage("StopBall");
            collinfo.gameObject.SendMessage("ResetBall");
            Player.gameObject.SendMessage("ResetBar");
            GameControler.PlayerLife -= 1;
        }

        if (collinfo.tag == "Power")
        {
            Player = GameObject.FindWithTag("Player").transform; 
        }

    }



}