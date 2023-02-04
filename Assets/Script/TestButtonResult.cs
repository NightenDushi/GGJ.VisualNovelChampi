using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TestButtonResult : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] int id;

    public void CloseMinigame()
    {
        MinigameManager.EndMinigame(id, SceneManager.GetActiveScene());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"Foo {id}");
        CloseMinigame();
    }
}
