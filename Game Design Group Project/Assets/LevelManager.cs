using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static bool OnWin = false;
    static bool OnLose = false;
    static int transitionNumber;
    static int levelNumber;
    static string[] levels = { "Level1", "Level2", "Level3", "Level4"};

    public static void win(int newTransitionNumber)
    {
        if (newTransitionNumber == 3)
        {
            SceneManager.LoadScene("PreBoss");
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
        Ladder.makeFalse();
        MeleeDeathZone.meleeMakeFalse();
        RangedDeathZone.rangedMakeFalse();
        Gun.GunReset();
        //LaserSpawner.SpawnerReset();
        OnWin = true;
        transitionNumber = newTransitionNumber;

    }

    public static void lose(int newLevelNumber)
    {
        SceneManager.LoadScene("Lose");
        Ladder.makeFalse();
        MeleeDeathZone.meleeMakeFalse();
        RangedDeathZone.rangedMakeFalse();
        Gun.GunReset();
        //LaserSpawner.SpawnerReset();
        OnLose = true;
        levelNumber = newLevelNumber;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.G) && OnWin == true)
        {
            Ladder.makeFalse();
            MeleeDeathZone.meleeMakeFalse();
            RangedDeathZone.rangedMakeFalse();
            Gun.GunReset();
            SceneManager.LoadScene(levels[transitionNumber]);
            OnWin = false;
        }
        else if (Input.GetKey(KeyCode.G) && OnLose == true)
        {
            Ladder.makeFalse();
            MeleeDeathZone.meleeMakeFalse();
            RangedDeathZone.rangedMakeFalse();
            Gun.GunReset();
            SceneManager.LoadScene(levels[levelNumber]);
            OnLose = false;
        }
    }
}