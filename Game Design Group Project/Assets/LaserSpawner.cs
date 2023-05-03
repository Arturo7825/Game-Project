using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject RightLaser;
    public GameObject LeftLaser;
    public Transform SpawnPoint;
    public AudioSource Shoot;
    static float count = 0;
    static bool canSwitchLeft = true;
    static bool canSwitchRight = false;
    // Update is called once per frame
    void Update()
    {
        if (AnimationController.getRight() == false && canSwitchLeft == true)
        {
            Vector2 target = new Vector2(transform.position.x - 1, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
            canSwitchLeft = false;
            canSwitchRight = true;
        }
        else if (AnimationController.getRight() == true && canSwitchRight == true)
        {
            Vector2 target = new Vector2(transform.position.x + 1, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, 1);
            canSwitchLeft = true;
            canSwitchRight = false;
        }
        count += 20f * Time.deltaTime;
        if (Input.GetKey(KeyCode.G))
        {
            if (count >= 20)
            {
                Shoot.Play();
                count = 0;
                if (AnimationController.getRight() == true)
                {
                    Instantiate(RightLaser, SpawnPoint.position, SpawnPoint.rotation); 
                }
                else
                {
                    Instantiate(LeftLaser, SpawnPoint.position, SpawnPoint.rotation); 
                }
            }
        }
    }
}
