using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum Pronoun
{
    IL, ELLE, IEL
}

public class Character : MonoBehaviour
{   

    public UnityEvent onUpdateSprite;
    public UnityEvent onUpdateColors;
    

    private int hatId;
    private Color hatColor = Color.white;
    private Color hatBottomColor = Color.white;

    private int eyeShapeId;
    private Color eyeColor = Color.white;

    private int bodyTypeId;
    private Color skinColor = Color.white;

    private int headId;

    private int noseId;
    private int mouthId;
    private int eyebrowId;
    private int torsoId;

    private float gender;

    private Pronoun pronoun;
    private string _name;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePronoun(int newPronoun)
    {
        this.pronoun = ((Pronoun) newPronoun);
    }

    public void ChangeName(string newName)
    {
        this._name = newName;
    }

    public void ChangeBodyType(int newBodyType)
    {
        this.bodyTypeId = newBodyType;
        UpdateSprite();
    }

    public void ChangeHat(int newHat)
    {
        this.hatId = newHat;
        UpdateSprite();
    }

    public void ChangeHead(int newHead)
    {
        this.headId = newHead;
        UpdateSprite();
    }

    public void ChangeEyeShape(int newEyeShape)
    {
        this.eyeShapeId = newEyeShape;
        UpdateSprite();
    }

    
    public void ChangeEyebrows(int newEyebrows)
    {
        this.eyebrowId = newEyebrows;
        UpdateSprite();
    }
    public void ChangeTorso(int newTorso)
    {
        this.torsoId = newTorso;
        UpdateSprite();
    }
    public void ChangeMouth(int newMouth)
    {
        this.mouthId = newMouth;
        UpdateSprite();
    }
    public void ChangeNose(int newNose)
    {
        this.noseId = newNose;
        UpdateSprite();
    }

    public void ChangeEyeColor(Color newEyeColor)
    {
        this.eyeColor = newEyeColor;
        UpdateColors();
    }

    public void ChangeSkinColor(Color newSkinColor)
    {
        this.skinColor = newSkinColor;
        UpdateColors();
    }

    public void ChangeHatColor(Color newHatColor)
    {
        this.hatColor = newHatColor;
        UpdateColors();
    }
    public void ChangeHatBottomColor(Color newHatColor)
    {
        this.hatBottomColor = newHatColor;
        UpdateColors();
    }

    void UpdateSprite()
    {
        CharacterSprite.HeadType_id = headId;
        CharacterSprite.BodyType_id = bodyTypeId;
        CharacterSprite.Eye_id = eyeShapeId;
        CharacterSprite.Hat_id = hatId;
        CharacterSprite.Torso_id = torsoId;
        CharacterSprite.Mouth_id = mouthId;
        CharacterSprite.Nose_id = noseId;
        CharacterSprite.Eyebrow_id = eyebrowId;

        onUpdateSprite.Invoke();
    }

    void UpdateColors()
    {
        CharacterSprite.HatColor = hatColor;
        CharacterSprite.HatBottomColor = hatBottomColor;
        CharacterSprite.EyeColor = eyeColor;
        CharacterSprite.SkinColor = skinColor;

        onUpdateColors.Invoke();
    }

    public void Confirm()
    {


        CharacterSprite.HeadType_id = headId;
        CharacterSprite.BodyType_id = bodyTypeId;
        CharacterSprite.Hat_id = hatId;
        CharacterSprite.Eye_id = eyeShapeId;
        CharacterSprite.Nose_id = noseId;
        CharacterSprite.Mouth_id = mouthId;
        CharacterSprite.Torso_id = torsoId;
        CharacterSprite.Eyebrow_id = torsoId;

        CharacterSprite.HatColor = hatColor;
        CharacterSprite.EyeColor = eyeColor;
        CharacterSprite.SkinColor = skinColor;

        CharacterSprite.Name = _name;
        CharacterSprite.Pronoun = pronoun;
        CharacterSprite.Gender = gender;

        ScreenCapture.CaptureScreenshot($"{_name}_le_super_shroom.png");
        Debug.Log("Screenshot enregistré!");

        SceneManager.LoadSceneAsync("SampleScene");
    }
    
    public void Shuffle()
    {
        Debug.Log("Shuffle...");

        headId = Random.Range(0, CharacterSprite.HeadList.Length);
        bodyTypeId = Random.Range(0, CharacterSprite.BodyList.Length);
        eyeShapeId = Random.Range(0, CharacterSprite.EyeList.Length);
        hatId = Random.Range(0, CharacterSprite.HatList.Length);
        torsoId = Random.Range(0, CharacterSprite.TorsoList.Length);
        mouthId = Random.Range(0, CharacterSprite.MouthList.Length);
        noseId = Random.Range(0, CharacterSprite.NoseList.Length);
        eyebrowId = Random.Range(0, CharacterSprite.EyebrowList.Length);

        eyeColor = Random.ColorHSV();
        skinColor = Random.ColorHSV();
        hatBottomColor = Random.ColorHSV();

        UpdateSprite();
        UpdateColors();
    }

    void logInfos()
    {
        Debug.Log("Nom : " + _name);
        Debug.Log("Pronom : " + pronoun);
        Debug.Log("Couleur de peau : " + skinColor.ToString());
        Debug.Log("Corps : " + bodyTypeId);
    }
}
