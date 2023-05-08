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
    static string[] levels = { "Level1", "Level2", "Level3", "Level4", "Level1"};

    public static void win(int newTransitionNumber)
    {
        if (newTransitionNumber == 3)
        {
            SceneManager.LoadScene("PreBoss");
        }
        else if (newTransitionNumber == 4)
        {
            SceneManager.LoadScene("FinalWin");
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
        Ladder.makeFalse();
        MeleeDeathZone.meleeMakeFalse();
        RangedDeathZone.rangedMakeFalse();
        Gun.GunReset();
        WallSensor.sensorMakeFalse();
        Boss.bossReset();
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
        WallSensor.sensorMakeFalse();
        Boss.bossReset();
        OnLose = true;
        levelNumber = newLevelNumber;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.V) && OnWin == true)
        {
            Ladder.makeFalse();
            MeleeDeathZone.meleeMakeFalse();
            RangedDeathZone.rangedMakeFalse();
            Gun.GunReset();
            WallSensor.sensorMakeFalse();
            SceneManager.LoadScene(levels[transitionNumber]);
            Boss.bossReset();
            OnWin = false;
        }
        else if (Input.GetKey(KeyCode.V) && OnLose == true)
        {
            Ladder.makeFalse();
            MeleeDeathZone.meleeMakeFalse();
            RangedDeathZone.rangedMakeFalse();
            Gun.GunReset();
            WallSensor.sensorMakeFalse();
            SceneManager.LoadScene(levels[levelNumber]);
            Boss.bossReset();
            OnLose = false;
        }
    }
}