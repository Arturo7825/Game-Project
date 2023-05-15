using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene3MusicPlayer : MonoBehaviour
{
    public AudioSource Music;
    void Update()
    {
        if (!Music.isPlaying)
        {
            Music.Play();
        }
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "FinalWin")
        {
            Destroy (this.gameObject);
        }
        GameObject.DontDestroyOnLoad(gameObject);
    }
}