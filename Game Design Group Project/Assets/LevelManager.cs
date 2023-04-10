using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static void win()
    {
        SceneManager.LoadScene("Win");
    }

    public static void lose()
    {
        SceneManager.LoadScene("Lose");
    }
}