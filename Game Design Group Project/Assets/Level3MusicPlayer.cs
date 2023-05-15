using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3MusicPlayer : MonoBehaviour
{
    public AudioSource Music;
    static bool first = true;
    void Update()
    {
        if (!Music.isPlaying && first == false)
        {
            Music.Play();
        }
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Lose")
        {
            Destroy (this.gameObject);
            first = false;
        }
        GameObject.DontDestroyOnLoad(gameObject);
    }
}