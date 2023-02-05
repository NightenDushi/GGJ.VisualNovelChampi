using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{   

    public UnityEvent onUpdateSprite;
    public UnityEvent onUpdateColors;
    
    private enum Pronoun
    {
        IL, ELLE, IEL
    }

    private int hatId;
    private Color hatColor = Color.white;

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
        UpdateSprite();
        UpdateColors();
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
        CharacterSprite.EyeColor = eyeColor;
        CharacterSprite.SkinColor = skinColor;

        onUpdateColors.Invoke();
    }

    public void Confirm()
    {   
        
    }

    void logInfos()
    {
        Debug.Log("Nom : " + _name);
        Debug.Log("Pronom : " + pronoun);
        Debug.Log("Couleur de peau : " + skinColor.ToString());
        Debug.Log("Corps : " + bodyTypeId);
    }
}
