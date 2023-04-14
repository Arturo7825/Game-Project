using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static string[] levels = { "Level1", "Level2" };
    public static void win(int transitionNumber)
    {
        SceneManager.LoadScene("Win");
        if(Input.GetKey(KeyCode.D))
        {
            //SceneManager.LoadScene(levels)
        }
    }

    public static void lose()
    {
        SceneManager.LoadScene("Lose");
    }
}