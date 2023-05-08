using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunImage : MonoBehaviour
{
    public GameObject Gun;
    public GameObject WinBarrier;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Gun.SetActive(true);
        WinBarrier.SetActive(true);
        Destroy(this.gameObject);
    }
}
