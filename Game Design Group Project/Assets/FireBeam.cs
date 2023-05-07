using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBeam : MonoBehaviour
{
    public static bool touching = false;
    public AudioSource Die;
    static float angle = -20;

    void FixedUpdate()
    {
        if (Boss.getFiring() == true)
        {
            angle += 3f * Time.deltaTime;
            if (angle >= 0)
            {
                Boss.shot();
            }
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            angle = -20;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touching = true;
            Die.Play();
            //LevelManager.lose(3);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
    }
    public bool getTouching()
    {
        return touching;
    }
    public static void makeFalse()
    {
        touching = false;
    }
}
