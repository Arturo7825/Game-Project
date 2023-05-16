using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneFireGun : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Cutscene4");
            CutsceneMeleeEnemy.Reset();
            Cutscene1Helicopter.Reset();
            Cutscene2Helicopter.Reset();
            Cutscene3Helicopter.Reset();
            CutsceneFireBeam.Reset();
        }
    }
}
