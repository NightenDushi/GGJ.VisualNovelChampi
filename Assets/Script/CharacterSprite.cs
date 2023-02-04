using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprite: MonoBehaviour
{
    [SerializeField] Texture2D[] _headList;
    [SerializeField] Texture2D[] _hatList;
    [SerializeField] Texture2D[] _bodyList;
    [SerializeField] Texture2D[] _eyeList;
    public static Texture2D[] HeadList;
    public static Texture2D[] HatList;
    public static Texture2D[] BodyList;
    public static Texture2D[] EyeList;

    public static int HeadType_id;
    public static int BodyType_id;
    public static int Hat_id;
    public static int EyeShape_id;

    public static Color HatColor;
    public static Color EyeColor;
    public static Color SkinColor;

    public static string Name;
    public static int Pronoun; //TODO Replace by enum
    public static float Gender;

    void Awake()
    {
        HeadList = _headList;
        HatList = _hatList;
        BodyList = _bodyList;
        EyeList = _eyeList;
    }

    public static Texture2D GetHead()
    {
        return HeadList[HeadType_id];
    }
    public static Texture2D GetHat()
    {
        return HatList[Hat_id];
    }
    public static Texture2D GetBody()
    {
        return BodyList[BodyType_id];
    }
    public static Texture2D GeyEye()
    {
        return EyeList[EyeShape_id];
    }

    private void OnValidate()
    {
        _headList = Resources.LoadAll<Texture2D>("Heads");
        _hatList = Resources.LoadAll<Texture2D>("Hats");
        _bodyList = Resources.LoadAll<Texture2D>("Bodies");
        _eyeList = Resources.LoadAll<Texture2D>("Eyes");
    }

}
