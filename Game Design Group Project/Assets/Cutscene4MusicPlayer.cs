using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene4MusicPlayer : MonoBehaviour
{
    public AudioSource Music;
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!Music.isPlaying && scene.name == "Cutscene4")
        {
            Music.Play();
        }
        
        if (scene.name == "Start")
        {
            Destroy(this.gameObject);
        }
        GameObject.DontDestroyOnLoad(gameObject);
    }
}