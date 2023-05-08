using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
    public static bool touchingWall = false;
    public AudioSource Die;
    public int levelNumber;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            touchingWall = true;
        }
        else if (collision.gameObject.tag == "Player" && Boss.getCharging() == true)
        {
            Die.Play();
            LevelManager.lose(levelNumber);
            FireGun.setState(3);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        touchingWall = false;
    }
    public static bool getTouchingWall()
    {
        return touchingWall;
    }
    public static void sensorMakeFalse()
    {
        touchingWall = false;
    }
}
