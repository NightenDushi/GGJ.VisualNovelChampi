using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Selector : MonoBehaviour
{
    public UnityEvent<int> onValueChanged;
    public Part part;

    private List<string> textureNames;
    private int currentTextureId = 0;

    public enum Part 
    {
        BODY, HEAD, HAT, EYES, NOSE, EYEBROWS, TORSO, MOUTH
    }

    private void Start() 
    {
        Texture2D[] textures = {};

        switch(part)
        {
            case Part.BODY : textures = CharacterSprite.BodyList; break;
            case Part.HEAD : textures = CharacterSprite.HeadList; break;
            case Part.HAT : textures = CharacterSprite.HatList; break;
            case Part.EYES : textures = CharacterSprite.EyeList; break;
            case Part.NOSE : textures = CharacterSprite.NoseList; break;
            case Part.EYEBROWS : textures = CharacterSprite.EyebrowList; break;
            case Part.TORSO : textures = CharacterSprite.TorsoList; break;
            case Part.MOUTH : textures = CharacterSprite.MouthList; break;
        }

        textureNames = new List<string>();

        foreach (Texture2D t in textures)
        {
            textureNames.Add(TextureName(t));
        }
        currentTextureId = GetBodyPartId();

        UpdateText();
    }
    private void OnEnable() => Character.onUpdateSpriteEvent += UpdateText;
    private void OnDisable() => Character.onUpdateSpriteEvent -= UpdateText;

    int GetBodyPartId()
    {
        switch (part)
        {
            case Part.BODY: return CharacterSprite.BodyType_id;
            case Part.HEAD: return CharacterSprite.HeadType_id;
            case Part.HAT: return CharacterSprite.Hat_id;
            case Part.EYES: return CharacterSprite.Eye_id;
            case Part.NOSE: return CharacterSprite.Nose_id;
            case Part.EYEBROWS: return CharacterSprite.Eyebrow_id;
            case Part.TORSO: return CharacterSprite.Torso_id;
            case Part.MOUTH: return CharacterSprite.Mouth_id;
            default:
                return currentTextureId; //Should not be reached, but just in case
        }
    }

    public void leftClicked()
    {   
        currentTextureId = mod(currentTextureId - 1, textureNames.Count);
        
        onValueChanged.Invoke(currentTextureId);
        UpdateText();
    }

    public void rightClicked()
    {
        currentTextureId = mod(currentTextureId + 1, textureNames.Count);
                
        onValueChanged.Invoke(currentTextureId);
        UpdateText();
    }

    void UpdateText()
    {
        currentTextureId = GetBodyPartId();
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(textureNames[currentTextureId]); //TODO(Nighten) Replace this get() by a serialized field
    }

    //Modulo qui ??vite de sortir des valeurs n??gatives
    int mod(int x, int m) {
        int r = x%m;
        return r<0 ? r+m : r;
    }

    //Vire le (UnityEngine.Texture2D) de Texture2D.ToString()
    string TextureName(Texture2D t)
    {
        return t.ToString().Substring(0, t.ToString().Length - " (UnityEngine.Texture2D)".Length);
    }
}
