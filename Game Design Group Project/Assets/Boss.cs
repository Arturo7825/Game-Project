using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
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
    public Rigidbody2D rigidbody;
    public AudioSource Swing;
    bool standing = false;
    public int levelNumber;
    //public float maxDifY;
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
        y = transform.position.y;
        playerPosX = AnimationController.getX();
        playerPosY = AnimationController.getY();
        //float playerPosY = AnimationController.getY()
        if (x < playerPosX)
        {
            animator.SetInteger("AnimState", 1);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            count = 0;
            x += 0.02f;
            standing = false;
        }
        else if (x > playerPosX)
        {
            animator.SetInteger("AnimState", 1);
            transform.localRotation = Quaternion.Euler(0, 360, 0);
            count = 0;
            //print("b");
            x -= 0.02f;
            standing = false;
        }
        Vector2 target = new Vector2(x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, 1);
    }
}