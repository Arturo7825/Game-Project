using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1Helicopter : MonoBehaviour
{
    Animator animator;
    static bool first = true;
    static bool collided = false;
    static bool played = false;
    public AudioSource BeamCharge;
    void FixedUpdate()
    {
        if (first == true)
        {
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
            FireGun.setState(1);
            if (played == false)
            {
                BeamCharge.Play();
                played = true;
            }
            if (Input.GetKey(KeyCode.V))
            {
                BeamCharge.Stop();
            }
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
        played = false;
    }

    public static bool getCollided()
    {
        return collided;
    }
}