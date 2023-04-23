using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    static float x = 0f;
    static float y = 0f;
    static float temp = 1f;
    public float jumpHeight;
    public float jumpWidth;
    static int jumpCount = 0;
    public Rigidbody2D rigidbody;
    //static int number = 0;
    static bool falling = false;
    public AudioSource jump;
    Vector2 position;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody2D>();
        x = transform.position.x;
        temp = y;
        y = transform.position.y;
        //if(temp != y)
        if(rigidbody.velocity.y < 0)
        {
            falling = true;
            //print(number);
           
        }
        else
        {
            falling = false;
            jumpCount = 0;
            //print("false");
        }
        //print(falling);
        /*
        if (jumpCount > 0)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
        */
        bool OnPlatform = Platform.getOnPlatform();
        bool onLadder = Ladder.getOnLadder();
        //if (Input.GetKey(KeyCode.W) && (OnPlatform == true && falling == false || jumpCount > 0 && falling == true && OnPlatform == false))
        //if (Input.GetKey(KeyCode.W) && (OnPlatform == true && falling == false || jumpCount > 0 && falling == true && OnPlatform == false))
        if (onLadder == true && Input.GetKey(KeyCode.W))
        {
            y += 0.002f;
            rigidbody.velocity = Vector3.zero;
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
        }
        else if (Input.GetKey(KeyCode.W) && (falling == false || jumpCount > 0 && falling == true))
        {
            //if (jumpCount == 0 && falling == false && OnPlatform == true)
            if (jumpCount == 0 && falling == false)
            {
                jumpCount = 150;
                jump.Play();
            }
            animator.SetInteger("AnimState", 2);
            //temp = y;
            //y += 0.03f;
            y += jumpHeight;
            if (Input.GetKey(KeyCode.A))
            {
                //x -= 0.005f;
                x -= jumpWidth;
                //transform.localRotation = Quaternion.Euler(0, 180, 0);
                animator.SetInteger("AnimState", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //x += 0.005f;
                x += jumpWidth;
                transform.localRotation = Quaternion.Euler(0, 360, 0);
                animator.SetInteger("AnimState", 1);
            }
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
            //GameObject.Find("Main Camera").transform.position = new Vector3(0 + x, 0 + y, -10);
            //falling = true;
        }
        if(jumpCount > 0)
        {
            jumpCount--;
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

    public static float getX()
    {
        return x;
    }
}
