using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    static bool canSwitchLeft = false;
    static bool canSwitchRight = true;
    void Update()
    {
        bool right = Boss.getRight();
        if (right == true)
        {
            //if (canSwitchRight == true)
            if (canSwitchLeft == true)
            {
                Vector2 target = new Vector2(transform.position.x - 2.7f, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, 1);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                canSwitchLeft = true;
                canSwitchRight = false;
            }
        }
        else if(right == false)
        {
            //if (canSwitchLeft == true)
            if (canSwitchRight == true)
            {
                Vector2 target = new Vector2(transform.position.x + 2.7f, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, 1);
                transform.localRotation = Quaternion.Euler(0, 360, 0);
                canSwitchLeft = false;
                canSwitchRight = true;
            }
        }
    }

    public static void FireGunReset()
    {
        if(Input.GetKey(KeyCode.A))
        {
            canSwitchLeft = true;
            canSwitchRight = false;
        }
    }
}
