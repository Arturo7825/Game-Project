using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene3Helicopter : MonoBehaviour
{
    Animator animator;
    static bool first = true;
    static bool collided = false;
    void FixedUpdate()
    {
        if (first == true)
        {
            first = false;
        }
        if (collided == false)
        {
            float y = transform.position.y + 0.07f;
            Vector2 target = new Vector2(transform.position.x, y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
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
        first = true;
        FireGun.setState(3);
    }
}