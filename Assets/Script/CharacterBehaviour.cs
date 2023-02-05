using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] Animator _anim;
    //[SerializeField] public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    public void Hide()
    {
        _anim.Play("FadeOut");
        Destroy(this.gameObject, 1f);
    }
}
