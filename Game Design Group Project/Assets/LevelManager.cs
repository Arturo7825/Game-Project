using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static bool OnWin = false;
    static int transitionNumber;
    static string[] levels = { "Level1", "Level2", "Level3" };

    public static void win(int newTransitionNumber)
    {
        SceneManager.LoadScene("Win");
        OnWin = true;
        transitionNumber = newTransitionNumber;

    }

    public static void lose()
    {
        SceneManager.LoadScene("Lose");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            SceneManager.LoadScene(levels[transitionNumber]);
            OnWin = false;
        }
    }
}