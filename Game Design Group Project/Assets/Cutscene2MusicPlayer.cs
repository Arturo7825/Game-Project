using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2MusicPlayer : MonoBehaviour
{
    public AudioSource Music;
    void Update()
    {
        if (!Music.isPlaying)
        {
            Music.Play();
        }
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "PreBoss")
        {
            Destroy (this.gameObject);
        }
        GameObject.DontDestroyOnLoad(gameObject);
    }
}