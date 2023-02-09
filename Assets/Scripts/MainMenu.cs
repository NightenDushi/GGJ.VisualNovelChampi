using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    public void Begin()
    {
        SceneManager.LoadSceneAsync("CharMaker");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
