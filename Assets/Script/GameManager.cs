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

    [SerializeField] CharacterBehaviour CharaPrefab;
    [SerializeField] CharacterBehaviour PNJ1Prefab;
    static CharacterBehaviour CharacterLeft;
    static CharacterBehaviour CharacterRight;

    [SerializeField] Vector3 CharacterLeft_Position;
    [SerializeField] Vector3 CharacterRight_Position;

    [SerializeField] GameObject CharacterParent;

    //Character appear left/right
    //NOTE(Nathan) Le perso de droite n'inverse pas ses animation d'apparition/Disparition


    [YarnCommand("show_chara")]
    public static void ShowCharacter(string pSide, string pChara="default")
    {
        if (pSide == "left")
        {
            if (CharacterLeft != null)
                CharacterLeft.Hide();
            CharacterLeft = Instantiate((pChara=="default")?Instance.CharaPrefab:Instance.PNJ1Prefab, Instance.CharacterParent.transform); //Instance.CharacterLeft_Position, Quaternion.identity);
            CharacterLeft.transform.localPosition = Instance.CharacterLeft_Position;
            //CharacterLeft.transform.parent = Instance.CharacterParent.transform;
        } else if (pSide == "right")
        {
            if (CharacterRight != null)
                CharacterRight.Hide();
            CharacterRight = Instantiate((pChara == "default") ? Instance.CharaPrefab : Instance.PNJ1Prefab, Instance.CharacterParent.transform);
            CharacterRight.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            CharacterRight.transform.localPosition = Instance.CharacterRight_Position;
            //CharacterRight.transform.parent = Instance.CharacterParent.transform;
        }
    }
    [YarnCommand("hide_chara")]
    public static void HideCharacter(string pSide)
    {
        if (pSide == "left")
        {
            if (CharacterLeft != null)
                CharacterLeft.Hide();
        } else if (pSide == "right")
        {
            if (CharacterRight != null)
                CharacterRight.Hide();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(CharacterLeft_Position, "Light Gizmo.tiff", true);
        Gizmos.DrawIcon(CharacterRight_Position, "Light Gizmo.tiff", true);
    }



}
