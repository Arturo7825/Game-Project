using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene2Helicopter : MonoBehaviour
{
    Animator animator;
    static bool first = true;
    static bool collided = false;
    public AudioSource Helicopter;
    void FixedUpdate()
    {
        if (!Helicopter.isPlaying)
        {
            Helicopter.Play();
        }
        if (collided == false)
        {
            float y = transform.position.y - 0.07f;
            Vector2 target = new Vector2(transform.position.x, y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
        }
        else
        {
            Helicopter.Stop();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CutsceneCollider")
        {
            collided = true;
        }
    }

    public static void Reset()
    {
        collided = false;
    }
}