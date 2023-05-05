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
        count += 20f * Time.deltaTime;
        if (Input.GetKey(KeyCode.G))
        {
            if (count >= 20)
            {
                Shoot.Play();
                count = 0;
                if (AnimationController.getRight() == true)
                {
                    Instantiate(RightLaser, SpawnPoint.position + new Vector3(-0.9f,0,0), SpawnPoint.rotation); 
                }
                else
                {
                    //Instantiate(LeftLaser, SpawnPoint.position + new Vector3(0.9f,0,0), SpawnPoint.rotation); 
                    Instantiate(LeftLaser, SpawnPoint.position + new Vector3(-2.7f,0,0), SpawnPoint.rotation); 
                }
            }
        }
    }

    public static void SpawnerReset()
    {
        canSwitchLeft = true;
        canSwitchRight = false;
    }
}
