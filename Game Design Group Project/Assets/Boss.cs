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
    static float count = 0;
    static bool first = true;
    Vector2 position;
    public AudioSource Die;
    public Rigidbody2D rigidbody;
    public AudioSource Swing;
    public int levelNumber;
    static bool right = false;
    static bool sideSwitch = false;
    static bool attacking = false;
    public GameObject FireWall;
    static bool charging = false;
    float chargingCount = 0;
    //Random r = new Random();
    int rnum = 0;
    //public float maxDifY;
    //public float initialPosY;
    //static float y = initialPosY;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attacking == false)
        {
            FireWall.SetActive(false);
            count += Time.deltaTime * 300;
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
                x += 0.015f;
                if (right == false)
                {
                    sideSwitch = true;
                }
                else
                {
                    sideSwitch = false;
                }
                right = true;
            }
            else if (x > playerPosX)
            {
                animator.SetInteger("AnimState", 1);
                transform.localRotation = Quaternion.Euler(0, 360, 0);
                if (right == true)
                {
                    sideSwitch = true;
                }
                else
                {
                    sideSwitch = false;
                }
                x -= 0.015f;
                right = false;
            }
            Vector2 target = new Vector2(x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
        }

        if(count >= 500 || attacking == true)
        {
            if (attacking == false)
            {
                attacking = true;
                //rnum = Random.Range(0, 2);
            }
            count = 0;
            rnum = 0;
            if(rnum == 0)
            {
                if (WallSensor.getTouchingWall() == false)
                {
                    chargingCount += Time.deltaTime * 300;
                    FireGun.setState(1);
                    charging = true;
                    FireWall.SetActive(true);
                    Vector2 target;
                    if (chargingCount >= 400)
                    {
                        FireGun.setState(2);
                        if (right == false)
                        {
                            target = new Vector2(transform.position.x-0.1f, transform.position.y);
                        }
                        else
                        {
                            target = new Vector2(transform.position.x+0.1f, transform.position.y);
                        }
                        transform.position = Vector2.MoveTowards(transform.position, target, 1);
                    }
                }
                else
                {
                    FireGun.setState(3);
                    attacking = false;
                    charging = false;
                    chargingCount = 0;
                }
            }
        }

    }

    public static bool getRight()
    {
        return right;
    }
    public static bool getSideSwitch()
    {
        return sideSwitch;
    }
    public static bool getCharging()
    {
        return charging;
    }
    public static void bossReset()
    {
        attacking = false;
        charging = false;
        count = 0;
        first = true;
    }
}