using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject Laser;
    public Transform SpawnPoint;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            Instantiate(Laser, SpawnPoint.position, SpawnPoint.rotation); 
        }
    }
}
