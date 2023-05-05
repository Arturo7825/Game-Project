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
    public int levelNumber;
    static int jumpCount = 0;
    static int slowFallCount = 0;
    public Rigidbody2D rigidbody;
    //static int number = 0;
    static bool falling = false;
    static bool right = true;
    public float dieLevel;
    public AudioSource jump;
    Vector2 position;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody2D>();
        x = transform.position.x;
        temp = y;
        y = transform.position.y;

        if (y <= dieLevel)
        {
            LevelManager.lose(levelNumber);
        }

        //if(temp != y)
        if(rigidbody.velocity.y < 0)
        {
            falling = true;
            //print(number);
            /*
            if (slowFallCount == 0)
            {
                rigidbody.velocity.y *= Time.DeltaTime;
                slowFallCount = 1;
            }*/
        }
        else
        {
            falling = false;
            jumpCount = 0;
            //slowFallCount = 0;
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
            y += 2f * Time.deltaTime;
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
            y += jumpHeight * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                right = false;
                //x -= 0.005f;
                x -= jumpWidth * Time.deltaTime;
                //transform.localRotation = Quaternion.Euler(0, 180, 0);
                animator.SetInteger("AnimState", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                right = true;
                //x += 0.005f;
                x += jumpWidth * Time.deltaTime;
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
            right = true;
            animator.SetInteger("AnimState", 1);
            transform.localRotation = Quaternion.Euler(0, 360, 0);
            //x += 0.003f;
            x += 1.8f * Time.deltaTime;
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("AnimState", 3);
            right = false;
            //x -= 0.003f;
            x -= 1.8f * Time.deltaTime;
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
    public static float getY()
    {
        return y;
    }
    public static bool getRight()
    {
        return right;
    }
}
