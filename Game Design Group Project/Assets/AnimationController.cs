using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    //static float x = 0.0f;
    //static float y = 0.0f;
    static float x = 0f;
    static float y = 0f;
    static int jumpCount = 0;
    Vector2 position;
    //public Vector3 myPos;
    //public Transform myPlay;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        bool OnPlatform = Platform.getOnPlatform();
        if (Input.GetKey(KeyCode.W) && OnPlatform == true || jumpCount > 0)
        {
            if(jumpCount == 0)
            {
                jumpCount = 150;
            }
            animator.SetInteger("AnimState", 2);
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
        }

        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("AnimState", 1);
            transform.localRotation = Quaternion.Euler(0, 360, 0);
            x += 0.003f;
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
            //GameObject.Find("Main Camera").transform.position = new Vector3(0 + x, 0 + y, -10);
            //transform.position = myPlay.position + myPos;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("AnimState", 3);
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            x -= 0.003f;
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
            //GameObject.Find("Main Camera").transform.position = new Vector3(0 + x, 0 + y, -10);
        }


        else
        {
            animator.SetInteger("AnimState", 0);
        }
        if (OnPlatform == false && jumpCount == 0)
        {
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                y = transform.position.y - 0.007f;
            }
            else
            {
                y = transform.position.y - 0.003f;
            }
            Vector2 target = new Vector2(0.0f + x, 0.0f + y);
            //GameObject.Find("Main Camera").transform.position = new Vector3(0 + x, 0 + y, -10);
        }
    }
}
