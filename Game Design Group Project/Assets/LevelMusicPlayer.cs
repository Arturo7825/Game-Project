using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicPlayer : MonoBehaviour
{
    public AudioSource Music;
    public string sceneName;
    static bool first = true;
    void Update()
    {
        if (!Music.isPlaying && first == true)
        {
            Music.Play();
            first = false;
        }
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == sceneName)
        {
            Destroy (this.gameObject);
            first = true;
        }
        GameObject.DontDestroyOnLoad(gameObject);
    }
}