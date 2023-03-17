using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static bool OnPlatform = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlatform = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        OnPlatform = false;
    }

    public static bool getOnPlatform()
    {
        return OnPlatform;
    }
}
