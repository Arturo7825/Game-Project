using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    static float x = 0.0f;
    static float playerPosX = AnimationController.getX();
    float count = 0;
    Vector2 position;
    //public float initialPosY;
    //static float y = initialPosY;

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        playerPosX = AnimationController.getX();
        //float playerPosY = AnimationController.getY()
        float difference = x - playerPosX;
        if (difference < 0)
        {
            difference = difference * -1;
        }
        if (playerPosX < 0)
        {
            playerPosX = playerPosX * -1;
        }
        if (difference < 0.03)
        {
            count++;
        }
        else if ( difference > 0.03)
        {
            count = 0;
        }
        else if (x < playerPosX)
        {
            x += -0.03f;
            transform.localRotation = Quaternion.Euler(0, 360, 0);
        }
        else if (x > playerPosX)
        {
            x -= 0.03f;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        Vector2 target = new Vector2(0.0f + x, 0.0f);
        transform.position = Vector2.MoveTowards(transform.position, target, 1);
    }
}