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

    // Start is called before the first frame update
    void Start()
    {   
        colorPicker = transform.GetChild(1).GetComponent<FlexibleColorPicker>();

        SetColor(defaultColor);
        colorPicker.SetColor(defaultColor);

        onColorChange.Invoke(defaultColor); //Set the default color
    }

    // Update is called once per frame
    void Update()
    {
        
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
