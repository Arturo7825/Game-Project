using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    Animator animator;
    int state = 0;
    //int count = 1;
    float count = 1f;
    bool first = true;
    public AudioSource Die;
    public AudioSource Charging;
    public AudioSource Fire;
    /*
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("AnimState", 0);
        print(state);
    }
    */

    // Update is called once per frame
    void FixedUpdate()
    {
        if (first == true)
        {
            animator = GetComponent<Animator>();
            animator.SetInteger("AnimState", 0);
            first = false;
        }
        if (count == 0)
        {
            if (state == 4)
            {
                state = 0;
            }
            if (state == 0)
            {
                Charging.Play();
                state = 1;
                animator.SetInteger("AnimState", 1);

            }
            else if (state == 1)
            {
                state = 2;
                animator.SetInteger("AnimState", 2);
                //count = 3000;
                count = 400;
            }
            else if (state == 2)
            {
                Fire.Play();
                state = 3;
                animator.SetInteger("AnimState", 3);
            }
            else if (state == 3)
            {
                Fire.Stop();
                state = 4;
                animator.SetInteger("AnimState", 4);
            }
        }
        if (state == 4 && Time.deltaTime < 0.005)
        {
            bool hit = RangedDeathZone.getHit();
            if (hit == true)
            {
                Die.Play();
                LevelManager.lose();
            }
        }
        else if (state == 3 && Time.deltaTime >= 0.005)
        {
            bool hit = RangedDeathZone.getHit();
            if (hit == true)
            {
                Die.Play();
                LevelManager.lose();
            }
        }
        //count++;
        /*
        if (Time.deltaTime < 0.005)
        {
            count += Time.deltaTime / 4;
        }
        else
        {
            count += Time.deltaTime;
        }*/
        count += Time.deltaTime * 300;
        //if (count == 4000)
        if (count >= 500)
        {
            count = 0;
        }
    }
}
