using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseFloor : MonoBehaviour
{
    //public LuigiLevelManager LevelManager;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        LevelManager.lose();
    }
}
