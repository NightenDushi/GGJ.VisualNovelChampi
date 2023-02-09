using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenuLogoFadein : MonoBehaviour
{
    [SerializeField] Image _render;

    // Start is called before the first frame update
    void Start()
    {
        _render.color = new Color(1f, 1f, 1f, 0f);
        //transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y);

        transform.DOLocalMoveY(0f, 1f).SetEase(Ease.OutBack).SetDelay(0.8f);
        _render.DOColor(Color.white, 0.8f).SetDelay(1f);
    }
}
