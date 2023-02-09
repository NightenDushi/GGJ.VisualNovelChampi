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
        DOVirtual.Float(0.0f, 0.9f, 0.5f, a => {
            Debug.Log(a);
            _render.color = new Color(0f, 0f, 0f, a);
        }).SetEase(Ease.OutBack);
        
    }

    private void OnDisable()
    {
        DOTween.KillAll();
    }

}
