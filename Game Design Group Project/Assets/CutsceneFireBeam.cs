using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFireBeam : MonoBehaviour
{
    public static bool touching = false;
    static float angle = -20;
    public AudioSource BeamFiring;

    void FixedUpdate()
    {
        if (angle < 23)
        {
            angle += 10f * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 180, angle);
            Vector2 target = new Vector2(transform.position.x,transform.position.y - 0.2f * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
        }/*
        else
        {
            Destroy (this.gameObject);
        }*/
    }

    public static void Reset()
    {
        angle = -20;
    }
}
