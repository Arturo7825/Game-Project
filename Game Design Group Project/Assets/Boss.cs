using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public AudioSource Charge;
    public AudioSource Fire;
    public AudioSource BeamCharge;
    public AudioSource BeamFiring;
    public int levelNumber;
    static bool right = false;
    static bool sideSwitch = false;
    static bool attacking = false;
    public GameObject FireWall;
    public GameObject FireBeam;
    //static GameObject FireBeam = GameObject.FindWithTag("Beam");
    static bool charging = false;
    static bool firing = false;
    float chargingCount = 0;
    //Random r = new Random();
    int rnum = 0;
    static bool hit = false;
    static int health = 15;
    //public float maxDifY;
    //public float initialPosY;
    //static float y = initialPosY;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attacking == false)
        {
            hit = false;
            FireWall.SetActive(false);
            FireBeam.SetActive(false);
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
                animator.SetInteger("AnimState", 0);
                attacking = true;
                rnum = Random.Range(0, 2);
            }
            count = 0;
            
            FireGun.setState(1);
            if (rnum == 0 && !Charge.isPlaying && chargingCount == 0)
            {
                Charge.Play();
            }
            else if (rnum == 1 && !BeamCharge.isPlaying && chargingCount == 0)
            {
                BeamCharge.Play();
            }
            chargingCount += Time.deltaTime * 300;
            if (chargingCount >= 200 && rnum == 1 && !BeamFiring.isPlaying)
            {
                //BeamCharge.Stop();
                //BeamFiring.Play();
                FireGun.setState(2);
            }
            else if (chargingCount >= 200 && rnum == 0 && !Fire.isPlaying)
            {
                //Charge.Stop();
                //Fire.Play();
                FireGun.setState(2);
            }
            
            if(rnum == 0)
            {
                if (WallSensor.getTouchingWall() == false)
                {
                    //Gun charging place
                    charging = true;
                    FireWall.SetActive(true);
                    Vector2 target;
                    //Gun firing place
                    if (chargingCount >= 200)
                    {
                        Charge.Stop();
                        if (!Fire.isPlaying)
                        {
                            Fire.Play();
                        }
                        animator.SetInteger("AnimState", 1);
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
                    Fire.Stop();
                    FireGun.setState(3);
                    attacking = false;
                    charging = false;
                    chargingCount = 0;
                }
            }
            else
            {
                if (chargingCount >= 200)
                {
                    BeamCharge.Stop();
                    if (!BeamFiring.isPlaying)
                    {
                        BeamFiring.Play();
                    }
                    if (hit == false)
                    {
                        FireBeam.SetActive(true);
                        firing = true;
                    }
                    else
                    {
                        attacking = false;
                        hit = false;
                        BeamFiring.Stop();
                        FireGun.setState(3);
                        chargingCount = 0;
                    }
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
        health = 15;
    }
    public static bool getFiring()
    {
        return firing;
    }
    public static bool getHit()
    {
        return hit;
    }
    public static void resetHit()
    {
        hit = false;
    }
    public static void resetHealth()
    {
        health = 15;
    }
    public static void shot()
    {
        hit = true;
        health--;
        if (health == 0)
        {
            //LevelManager.win("Start", "FinalWin");
            SceneManager.LoadScene("Level4-2");
        }
        if (firing == true)
        {
            firing = false;
        }
    }
}