using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    static bool canSwitchLeft = true;
    static bool canSwitchRight = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (canSwitchRight == true)
            {
                Vector2 target = new Vector2(transform.position.x + 2.7f, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, 1);
                transform.localRotation = Quaternion.Euler(0, 360, 0);
                canSwitchLeft = true;
                canSwitchRight = false;
            }
        }
        else if(Input.GetKey(KeyCode.A))
        {
            if (canSwitchLeft == true)
            {
                Vector2 target = new Vector2(transform.position.x - 2.7f, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, 1);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                canSwitchLeft = false;
                canSwitchRight = true;
            }
        }
    }
}
