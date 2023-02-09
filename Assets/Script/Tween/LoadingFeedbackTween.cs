using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingFeedbackTween : MonoBehaviour
{
    [SerializeField] Image _render;

    private void OnEnable()
    {
        Debug.Log("Enable");
        _render.color = new Color(0f, 0f, 0f, 0f);
        _render.DOColor(new Color(0f, 0f, 0f, 0.9f), 0.8f).SetEase(Ease.OutBack);
        
    }

    private void OnDisable()
    {
        DOTween.KillAll();
    }

}
