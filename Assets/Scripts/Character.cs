using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{   

    
    private enum Pronoun
    {
        IL, ELLE, IEL
    }

    private enum BodyType
    {
        UN, DEUX, TROIS
    }

    private enum Hat
    {

    }

    private enum EyeShape
    {

    }

    private enum NoseShape
    {

    }

    private Hat hat;
    private Color hatColor;

    private EyeShape eyeShape;
    private Color eyeColor;

    private NoseShape noseShape;

    private BodyType bodyType;
    private Color skinColor;

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
        this.bodyType = ((BodyType) newBodyType);
        UpdatePortrait();
    }

    public void ChangeHat(int newHat)
    {
        this.hat = ((Hat) newHat);
        UpdatePortrait();
    }

    public void ChangeNoseShape(int newNoseShape)
    {
        this.noseShape = ((NoseShape) newNoseShape);
        UpdatePortrait();
    }

    public void ChangeEyeShape(int newEyeShape)
    {
        this.eyeShape = ((EyeShape) newEyeShape);
        UpdatePortrait();
    }

    void UpdatePortrait()
    {

    }

    public void Confirm()
    {   
        Debug.Log("Nom : " + this._name);
        Debug.Log("Pronoun : " + this.pronoun);
    }
}
