using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBarrier : MonoBehaviour
{
    public int transitionNumber;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Ladder.makeFalse();
        LevelManager.win(transitionNumber);
    }
}
