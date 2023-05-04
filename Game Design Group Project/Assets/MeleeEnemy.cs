using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    static float x = 0.0f;
    static float y = 0.0f;
    static float playerPosX = AnimationController.getX();
    static float playerPosY = AnimationController.getY();
    Animator animator;
    float count = 0;
    bool first = true;
    Vector2 position;
    public AudioSource Die;
    public float AggroDistance;
    public Rigidbody2D rigidbody;
    public AudioSource Swing;
    bool standing = false;
    //public float initialPosY;
    //static float y = initialPosY;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (first == true)
        {
            animator = GetComponent<Animator>();
            first = false;
        }
        x = transform.position.x;
        playerPosX = AnimationController.getX();
        playerPosY = AnimationController.getY();
        //float playerPosY = AnimationController.getY()
        float differenceX = x - playerPosX;
        float differenceY = y - playerPosY;
        if (differenceX < 0)
        {
            differenceX = differenceX * -1;
        }

        if (differenceY < 0)
        {
            differenceY = differenceY * -1;
        }
        // if (playerPosX < 0)
        // {
        //     playerPosX = playerPosX * -1;
        // }
        // print("x: "+ x);
        // print("playerPosX: "+playerPosX);
        //print(differenceY);
        if (differenceX < 1.66 && differenceY < 3.2 && rigidbody.velocity.y >= 0 || standing == true)
        {
            standing = true;
            animator.SetInteger("AnimState", 1);
            if ( count == 40)
            {
                Swing.Play();
                animator.SetInteger("AnimState", 2);
                bool hit = MeleeDeathZone.getHit();
                //print("differenceX: " + differenceX);
                //print("hit: " + hit);
                if (hit == true && differenceX < 1.66 && differenceY < 3.2 && rigidbody.velocity.y >= 0)
                {
                    Die.Play();
                    LevelManager.lose();
                }
                    count = 0;
                    standing = false;
                }
            else
            {
                count++;
            }
        }
        else if (x < playerPosX && differenceX < AggroDistance)
        {
            animator.SetInteger("AnimState", 0);
            count = 0;
            x += 0.03f;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            standing = false;
        }
        else if (x > playerPosX && differenceX < AggroDistance)
        {
            animator.SetInteger("AnimState", 0);
            count = 0;
            //print("b");
            x -= 0.03f;
            transform.localRotation = Quaternion.Euler(0, 360, 0);
            standing = false;
        }
        else if (differenceX >= AggroDistance)
        {
            animator.SetInteger("AnimState", 1);
            standing = false;
        }
        Vector2 target = new Vector2(x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, 1);
    }
}