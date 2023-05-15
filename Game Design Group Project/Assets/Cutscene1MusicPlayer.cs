using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene1MusicPlayer : MonoBehaviour
{
    public AudioSource Music;
    static int vCount = 0;
    void Update()
    {
        if ((Cutscene1Helicopter.getCollided() == true || Input.GetKey(KeyCode.V)) && !Music.isPlaying)
        {
            Music.Play();
        }
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level2")
        {
            Destroy (this.gameObject);
        }
        GameObject.DontDestroyOnLoad(gameObject);
    }
}