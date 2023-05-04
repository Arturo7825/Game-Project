using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDeathZone : MonoBehaviour
{
    static bool hit = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hit = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hit = false;
        }
    }

    public static bool getHit()
    {
        return hit;
    }
}
