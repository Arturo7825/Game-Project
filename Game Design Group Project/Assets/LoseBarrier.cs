using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBarrier : MonoBehaviour
{
    public AudioSource Die;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Die.Play();
        LevelManager.lose();
    }
}
