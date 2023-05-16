using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene4MusicPlayer : MonoBehaviour
{
    public AudioSource Music;
    static bool first = true;
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!Music.isPlaying && ((scene.name == "Start" && first == true) || (scene.name == "Cutscene4" && first == false)))
        {
            Music.Play();
            first = false;
        }
        
        if (scene.name == "Cutscene0")
        {
            Music.Stop();
        }
        GameObject.DontDestroyOnLoad(gameObject);
    }
}