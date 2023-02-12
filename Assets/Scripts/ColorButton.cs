using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorButton : MonoBehaviour, IPointerEnterHandler
{

    public Color defaultColor;
    public UnityEvent<Color> onColorChange;
    private FlexibleColorPicker colorPicker;
    private Color color;

    public enum ColorPart
    {
        HAT, HAT_BOTTOM, EYES, BODY
    }

    public ColorPart Part;

    // Start is called before the first frame update
    void Start()
    {   
        colorPicker = transform.GetChild(1).GetComponent<FlexibleColorPicker>();

        SetColor(defaultColor);
        colorPicker.SetColor(defaultColor);

        onColorChange.Invoke(defaultColor); //Set the default color
    }

    private void OnEnable() => Character.onUpdateColorsEvent += UpdateColor;
    private void OnDisable() => Character.onUpdateColorsEvent -= UpdateColor;


    private void UpdateColor() //Update the color after external changes
    {
        Color newColor;
        switch (Part)
        {
            case ColorPart.HAT:
                newColor = CharacterSprite.HatColor;
                break;
            case ColorPart.HAT_BOTTOM:
                newColor = CharacterSprite.HatBottomColor;
                break;
            case ColorPart.EYES:
                newColor = CharacterSprite.EyeColor;
                break;
            case ColorPart.BODY:
                newColor = CharacterSprite.SkinColor;
                break;
            default:
                newColor = color;
                break;
        }

        SetColor(newColor);
    }

    private void SetColor(Color color)
    {   
        colorPicker.startingColor = color;
        gameObject.GetComponent<Image>().color = color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {   
        colorPicker.gameObject.SetActive(true);
    }

    public void MouseExit()
    {
        colorPicker.gameObject.SetActive(false);
    }

    public void ChangeColor(Color newColor){
        SetColor(newColor);
        onColorChange.Invoke(newColor);
    }
}
