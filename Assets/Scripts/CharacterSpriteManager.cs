using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpriteManager : MonoBehaviour
{
    public Image BodySprite;
    public Image TorsoSprite;
    public Image HeadSprite;
    public Image MouthSprite;
    public Image NoseSprite;
    public Image EyebrowSprite;
    public Image EyesSprite;
    public Image HatSprite;

    public void UpdateSprite()
    {
        Texture2D t;

        t = CharacterSprite.GetBody();
        BodySprite.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0,0), 1);

        t = CharacterSprite.GetTorso();
        TorsoSprite.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0,0), 1);

        t = CharacterSprite.GetHead();
        HeadSprite.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0,0), 1);

        t = CharacterSprite.GetMouth();
        MouthSprite.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0,0), 1);

        t = CharacterSprite.GetNose();
        NoseSprite.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0,0), 1);
        
        t = CharacterSprite.GetEyebrow();
        EyebrowSprite.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0,0), 1);
        
        t = CharacterSprite.GetEye();
        EyesSprite.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0,0), 1);

        t = CharacterSprite.GetHat();
        HatSprite.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0,0), 1);
    }

    public void UpdateColors()
    {   
        //SkinColor
        BodySprite.color = CharacterSprite.SkinColor;
        HeadSprite.color = CharacterSprite.SkinColor;
        TorsoSprite.color = CharacterSprite.SkinColor;
        NoseSprite.color = CharacterSprite.SkinColor;
        MouthSprite.color = CharacterSprite.SkinColor;
        EyebrowSprite.color = CharacterSprite.SkinColor;

        //HatColor
        HatSprite.color = CharacterSprite.HatColor;

        //EyeColor
        EyesSprite.color = CharacterSprite.EyeColor;
    }
}
