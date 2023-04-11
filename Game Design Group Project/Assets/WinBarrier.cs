using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBarrier : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        LevelManager.win();
    }
}
