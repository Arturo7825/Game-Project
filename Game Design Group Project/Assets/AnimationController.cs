using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    static float x = 0f;
    static float y = 0f;
    static float temp = 1f;
    static int jumpCount = 0;
    static int number = 0;
    static bool falling = false;
    Vector2 position;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        //temp = y;
        y = transform.position.y;
        if(temp != y)
        {
            //falling = true;
            //print("true");
            //print(number);
            number++;
        }
        else
        {
            //falling = false;
            //print("false");
        }
        if (jumpCount > 0)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
        bool OnPlatform = Platform.getOnPlatform();
        if (Input.GetKey(KeyCode.W) && (OnPlatform == true && falling == false || jumpCount > 0 && falling == true && OnPlatform == false))
        {
            if (jumpCount == 0)
            {
                jumpCount = 150;
            }
            animator.SetInteger("AnimState", 2);
            //temp = y;
            y += 0.03f;
            if (Input.GetKey(KeyCode.A))
            {
                x -= 0.003f;
                //transform.localRotation = Quaternion.Euler(0, 180, 0);
                animator.SetInteger("AnimState", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                x += 0.003f;
                transform.localRotation = Quaternion.Euler(0, 360, 0);
                animator.SetInteger("AnimState", 1);
            }
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
            //GameObject.Find("Main Camera").transform.position = new Vector3(0 + x, 0 + y, -10);
            jumpCount--;
            //falling = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("AnimState", 1);
            transform.localRotation = Quaternion.Euler(0, 360, 0);
            x += 0.003f;
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("AnimState", 3);
            x -= 0.003f;
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
        }


        else
        {
            animator.SetInteger("AnimState", 0);
        }
        //if (OnPlatform == false && jumpCount == 0 && transform.position.y != y)
        //if (jumpCount == 0 && transform.position.y != y)
        /*
        if (jumpCount != 0)
        {
            falling = true;
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                y = transform.position.y - 0.007f;
            }
            else
            {
                animator.SetInteger("AnimState", 2);
                y = transform.position.y - 0.003f;
            }
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
        }
        else
        {
            falling = false;
        }
        */
        //temp = y;
    }
}
