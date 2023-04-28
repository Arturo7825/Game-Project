using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    static float x = 0.0f;
    static float playerPosX = AnimationController.getX();
    Animator animator;
    float count = 0;
    bool first = true;
    Vector2 position;
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
        //float playerPosY = AnimationController.getY()
        float difference = x - playerPosX;
        if (difference < 0)
        {
            difference = difference * -1;
        }
        // if (playerPosX < 0)
        // {
        //     playerPosX = playerPosX * -1;
        // }
        // print("x: "+ x);
        // print("playerPosX: "+playerPosX);
        print(difference);
        if (difference < 1.66)
        {
            animator.SetInteger("AnimState", 1);
            if ( count == 40)
            {
                animator.SetInteger("AnimState", 2);
                count = 0;
            }
            else
            {
                count++;
            }
        }
        else if (x < playerPosX)
        {
            animator.SetInteger("AnimState", 0);
            count = 0;
            //print("a");
            x += 0.03f;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (x > playerPosX)
        {
            animator.SetInteger("AnimState", 0);
            count = 0;
            //print("b");
            x -= 0.03f;
            transform.localRotation = Quaternion.Euler(0, 360, 0);
        }
        Vector2 target = new Vector2(x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, 1);
    }
}