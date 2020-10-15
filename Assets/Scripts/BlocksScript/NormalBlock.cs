using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBlock: MonoBehaviour
{
      
    GameObject Power;

  void SetPower(GameObject power)
    {
        Power = power;
 
    }

    void TriggerActive()
    {
        if (Power != null)
        {
            Power.SetActive(true);
            Power.GetComponent<Rigidbody2D>().gravityScale = .4f;
        }
    }


    void Resize()
    {
        Vector2 screenToBlock = new Vector2(

            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x / 5f,
            transform.localScale.y
            );
        Vector2 screenStartingPoint = new Vector2(
            Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x,
            0f
            );
        transform.localScale = screenToBlock;  // new Vector2(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f); 
    }

    void OnCollisionEnter2D(Collision2D coliInfo)
    {
        if (coliInfo.collider.tag == "Ball") {
            GameManager.NormalBlockLife -= GameManager.BallHItValue;
            if (GameManager.NormalBlockLife <= 0)
            {
                Destroy(this.gameObject);
                TriggerActive();
                GameControler.Score += GameControler.NormalBlockPerScore;
                GameControler.NormalBlockNumber += 1;
            }
           // coliInfo.gameObject.SendMessage("SmallPushBall");
        }


        
}


}
