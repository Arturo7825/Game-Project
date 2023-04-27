using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDeathZone : MonoBehaviour
{
    static bool hit = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        hit = false;
    }

    public static bool getHit()
    {
        return hit;
    }
}
