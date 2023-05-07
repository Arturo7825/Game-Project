using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLaser : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(transform.position.x + 8f * Time.deltaTime, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, 1);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            Destroy (this.gameObject);
            Boss.shot();
        }
        else if (collision.gameObject.tag == "Trigger" && Boss.getCharging() == true)
        {
            Destroy (this.gameObject);
        }
        else if (collision.gameObject.tag != "Player" && collision.gameObject.tag == "Enemy")
        {
            Destroy (this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Untagged")
        {
            Destroy (this.gameObject);
        }
    }
}
