using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [ContextMenu("Next Scene")]
    public void LoadNextScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        int sceneLimit = SceneManager.sceneCountInBuildSettings;
        int nextSceneIndex = i + 1;

        if (nextSceneIndex >= sceneLimit)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}