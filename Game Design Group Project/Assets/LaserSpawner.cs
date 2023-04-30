using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject RightLaser;
    public GameObject LeftLaser;
    public Transform SpawnPoint;
    static float count = 0;
    // Update is called once per frame
    void Update()
    {
        count += 1;
        if (Input.GetKey(KeyCode.G))
        {
            if (count >= 200)
            {
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
