using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBarrier : MonoBehaviour
{
    public string sceneName;
    public string winName;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        LevelManager.win(sceneName, winName);
    }
}
