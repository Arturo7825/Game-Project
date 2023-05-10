using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneMeleeEnemy : MonoBehaviour
{
    Animator animator;
    static bool first = true;
    static bool collided = false;
    void FixedUpdate()
    {
        if (first == true)
        {
            animator = GetComponent<Animator>();
            first = false;
        }
        if (collided == false)
        {
            float x = transform.position.x - 0.03f;
            Vector2 target = new Vector2(x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
        }
        else
        {
            animator.SetInteger("AnimState", 1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CutsceneCollider")
        {
            collided = true;
        }
    }
}