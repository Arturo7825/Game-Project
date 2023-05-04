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
    static string[] levels = { "Level1", "Level2", "Level3"};

    public static void win(int newTransitionNumber)
    {
        SceneManager.LoadScene("Win");
        OnWin = true;
        transitionNumber = newTransitionNumber;

    }

    public static void lose(int newLevelNumber)
    {
        SceneManager.LoadScene("Lose");
        OnLose = true;
        levelNumber = newLevelNumber;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.G) && OnWin == true)
        {
            SceneManager.LoadScene(levels[transitionNumber]);
            OnWin = false;
        }
        else if (Input.GetKey(KeyCode.G) && OnLose == true)
        {
            SceneManager.LoadScene(levels[transitionNumber]);
            OnLose = false;
        }
    }
}