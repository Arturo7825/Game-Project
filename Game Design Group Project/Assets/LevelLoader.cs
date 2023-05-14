using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string sceneName;
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            SceneManager.LoadScene(sceneName);
            CutsceneMeleeEnemy.Reset();
        }
    }
}
