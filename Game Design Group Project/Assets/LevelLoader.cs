using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string sceneName;
    public bool canQuit;
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            SceneManager.LoadScene(sceneName);
            CutsceneMeleeEnemy.Reset();
            Cutscene1Helicopter.Reset();
            Cutscene2Helicopter.Reset();
            Cutscene3Helicopter.Reset();
            CutsceneFireBeam.Reset();
            Gun.GunReset();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            if (canQuit == true)
            {
                Application.Quit();
            }
        }
    }
}
