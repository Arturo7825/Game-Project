using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public static bool onLadder = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        onLadder = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        onLadder = false;
    }
    public static bool getOnLadder()
    {
        return onLadder;
    }
}
