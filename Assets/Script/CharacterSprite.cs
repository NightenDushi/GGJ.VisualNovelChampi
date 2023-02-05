using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprite: MonoBehaviour
{
    [SerializeField] Texture2D[] _headList;
    [SerializeField] Texture2D[] _hatList;
    [SerializeField] Texture2D[] _bodyList;
    [SerializeField] Texture2D[] _eyeList;
    [SerializeField] Texture2D[] _noseList;/////
    [SerializeField] Texture2D[] _mouthList;
    [SerializeField] Texture2D[] _torsoList;
    [SerializeField] Texture2D[] _eyebrowList;

    public static Texture2D[] HeadList;
    public static Texture2D[] HatList;
    public static Texture2D[] BodyList;
    public static Texture2D[] EyeList;
    public static Texture2D[] NoseList;/////
    public static Texture2D[] MouthList;
    public static Texture2D[] TorsoList;
    public static Texture2D[] EyebrowList;

    public static int HeadType_id;
    public static int BodyType_id;
    public static int Hat_id;
    public static int Eye_id;
    public static int Nose_id;//////
    public static int Mouth_id;
    public static int Torso_id;
    public static int Eyebrow_id;

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

        NoseList = _noseList;
        MouthList = _mouthList;
        TorsoList = _torsoList;
        EyebrowList = _eyebrowList;
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
    public static Texture2D GetEye()
    {
        return EyeList[Eye_id];
    }

    public static Texture2D GetNose()
    {
        return NoseList[Nose_id];
    }

    public static Texture2D GetMouth()
    {
        return MouthList[Mouth_id];
    }

    public static Texture2D GetTorso()
    {
        return TorsoList[Torso_id];
    }

    public static Texture2D GetEyebrow()
    {
        return EyebrowList[Eyebrow_id];
    }

    private void OnValidate()
    {
        _headList = Resources.LoadAll<Texture2D>("Heads");
        _hatList = Resources.LoadAll<Texture2D>("Hats");
        _bodyList = Resources.LoadAll<Texture2D>("Bodies");
        _eyeList = Resources.LoadAll<Texture2D>("Eyes");

        _noseList = Resources.LoadAll<Texture2D>("Noses");
        _mouthList = Resources.LoadAll<Texture2D>("Mouths");
        _torsoList = Resources.LoadAll<Texture2D>("Torsos");
        _eyebrowList = Resources.LoadAll<Texture2D>("Eyebrows");
    }
}
