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
        if (Input.GetKey(KeyCode.V))
        {
            vCount++;
        }
        /*
        if (vCount == 2)
        {
            Destroy (this.gameObject);
            vCount = 0;
        }*/
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level2")
        {
            Destroy (this.gameObject);
        }
        GameObject.DontDestroyOnLoad(gameObject);
    }
}