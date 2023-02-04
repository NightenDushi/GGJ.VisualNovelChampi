using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MinigameManager
{
    public static event Action<int> OnEndMinigame;
    public static void EndMinigame(int pResult, Scene pSceneName)
    {
        Debug.Log($"Minigame Finished with result : {pResult}");
        Debug.Log($"Unloading scene : {pSceneName}");
        OnEndMinigame?.Invoke(pResult);

        SceneManager.UnloadSceneAsync(pSceneName);
    }
}
