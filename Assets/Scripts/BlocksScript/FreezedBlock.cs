using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezedBlock : MonoBehaviour
{
    // Start is called before the first frame update
    private int BlockLife = GameManager.FreezedBlockLife;
    // Update is called once per frame

    public Sprite _2ndTouch;
    public Sprite _3ndTouch;
 
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




    void OnCollisionEnter2D(Collision2D coliInfo)
    {
        if (coliInfo.collider.tag == "Ball")
        {
            BlockLife -= GameManager.BallHItValue;


            if (BlockLife <= 0)
            {
                Destroy(this.gameObject);
                GameControler.Score += GameControler.FreezedBlockPerScore;
                TriggerActive();

            }
            else if (BlockLife == 2)
            {
                transform.gameObject.GetComponent<SpriteRenderer>().sprite = _2ndTouch;
            }
            else if (BlockLife == 1)
            {
                transform.gameObject.GetComponent<SpriteRenderer>().sprite = _3ndTouch;
            }


            Debug.Log(transform.name + " " + BlockLife);
        }

    }
}
