using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    Animator animator;
    int state = 0;
    int count = 1;
    bool first = true;
    public AudioSource Die;
    /*
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("AnimState", 0);
        print(state);
    }
    */

    // Update is called once per frame
    void Update()
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
                state = 1;
                animator.SetInteger("AnimState", 1);

            }
            else if (state == 1)
            {
                state = 2;
                animator.SetInteger("AnimState", 2);
                count = 3000;
            }
            else if (state == 2)
            {
                state = 3;
                animator.SetInteger("AnimState", 3);
            }
            else if (state == 3)
            {
                state = 4;
                animator.SetInteger("AnimState", 4);
            }
        }
        if (state == 4)
        {
            bool hit = RangedDeathZone.getHit();
            if (hit == true)
            {
                Die.Play();
                LevelManager.lose();
            }
        }
        count++;
        if (count == 4000)
        {
            count = 0;
        }
    }

    private static IEnumerator Wait()
    {
        print("a");
        yield return new WaitForSeconds(3000.0f);
    }
}
