using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{   

    
    private enum Pronoun
    {
        IL, ELLE, IEL
    }

    private int hatId;
    private Color hatColor;

    private int eyeShapeId;
    private Color eyeColor;

    private int bodyTypeId;
    private Color skinColor;

    private int headId;

    private float gender;

    private Pronoun pronoun;
    private string _name;

    // Start is called before the first frame update
    void Start()
    {
        
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
        UpdatePortrait();
    }

    public void ChangeHat(int newHat)
    {
        this.hatId = newHat;
        UpdatePortrait();
    }

    public void ChangeHead(int newHead)
    {
        this.headId = newHead;
        UpdatePortrait();
    }

    public void ChangeEyeShape(int newEyeShape)
    {
        this.eyeShapeId = newEyeShape;
        UpdatePortrait();
    }

    public void ChangeEyeColor(Color newEyeColor)
    {
        this.eyeColor = newEyeColor;
    }

    public void ChangeSkinColor(Color newSkinColor)
    {
        this.skinColor = newSkinColor;
    }

    public void ChangeHatColor(Color newHatColor)
    {
        this.hatColor = newHatColor;
    }

    void UpdatePortrait()
    {

    }

    public void Confirm()
    {   
        logInfos();
    }

    void logInfos()
    {
        Debug.Log("Nom : " + _name);
        Debug.Log("Pronom : " + pronoun);
        Debug.Log("Couleur de peau : " + skinColor.ToString());
    }
}
