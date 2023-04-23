using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    static float x = transform.position.x;
    static float playerPosX = AnimationController.getX();
    //public float initialPosY;
    //static float y = initialPosY;

    // Update is called once per frame
    IEnumerator Update()
    {
        playerPosX = AnimationController.getX();
        //float playerPosY = AnimationController.getY()
        float difference = x - playerPosX;
        if(difference < 0)
        {
            difference = difference * -1;
        }
        if (difference < 0.03)
        {
            yield return new WaitForSeconds (3.0f);
        }
        else if(x < playerPosX)
        {
            x -= -0.03f;
        }
        else if(x > playerPosX)
        {
            x+= 0.03f;
        }

    }
}