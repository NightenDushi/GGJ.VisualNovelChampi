using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(Instance.gameObject);
    }

    private void OnEnable()
    {
        MinigameManager.OnEndMinigame += ProcessMinigameResult;
    }

    private void OnDisable()
    {
        MinigameManager.OnEndMinigame -= ProcessMinigameResult;
    }
    private void ProcessMinigameResult(int pResult)
    {
        YarnInstance.Variable.SetValue("$minigame_result", (float)pResult);
        string callback;
        bool value =  YarnInstance.Variable.TryGetValue<string>("$minigame_callback", out callback);
        YarnInstance.Dial.StartDialogue(callback);
    }

    [YarnCommand("minigame")]
    public static void InvokeMinigame(string pMinijeux)
    {
        Instance.StartCoroutine(LoadAsyncScene(pMinijeux));
    }

    static IEnumerator LoadAsyncScene(string pMinijeux)
    {
        //NOTE(Nathan) LOADING SCREEN HERE

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(pMinijeux, LoadSceneMode.Additive);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(pMinijeux));

        //NOTE(Nathan) REMOVE LOADING SCREEN HERE
    }



}
