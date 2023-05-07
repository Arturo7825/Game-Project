using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    static bool canSwitchLeft = false;
    static bool canSwitchRight = true;
    static int state = 0;
    bool first = true;
    Animator animator;
    void FixedUpdate()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("AnimState", state);
    }
    public static void setState(int num)
    {
        state = num;
    }
}
