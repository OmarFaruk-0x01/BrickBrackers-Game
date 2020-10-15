using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dec_Bar_Size : MonoBehaviour
{
    private Transform Player;

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

            GameManager.BarSizeX = GameManager.BarBaseSizeX - .2f;
        }
    }
}
