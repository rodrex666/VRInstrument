using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string nextScene;
    public void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void LoadSceneAsync(String sceneName)
    {
        StartCoroutine(LoadThisSceneAsync(sceneName));
    }

    IEnumerator LoadThisSceneAsync(String name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
