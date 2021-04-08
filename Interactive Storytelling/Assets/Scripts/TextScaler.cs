using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScaler : MonoBehaviour
{
    public float divider = 11.97f; //de value die gebruikt wordt om de textSize te berekenen
    public axis side = axis.Width; //welke axis het moet gebruiken

    //de Enum
    public enum axis
    {
        Width,
        Height
    }

    //laatste size zodat het niet te veel berekeningen doet
    float lastSize = 0;

    //benodigde components
    RectTransform rectTransform;
    Text text;

    void Start(){
        //de componenten pakken
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<Text>();
    }

    //bool buiten de update zodat het niet elke keer geinitialiseerd word
    bool changed = false;
    void Update()
    {  
        
        //kijken of de size verandert is en zoja het veranderen, en changed naar true zetten.
        if(side == axis.Width && rectTransform.rect.width != lastSize){
            lastSize = rectTransform.rect.width;
            changed = true;
        }
        else if(side == axis.Height && rectTransform.rect.height != lastSize){
           lastSize = rectTransform.rect.height;
           changed = true;
        }
    
        if(Application.isEditor && !changed){
            bool b1 = text.fontSize == (int)Mathf.Floor(lastSize/divider);
            if(b1) return;
            changed = true;
        }
        //gridlayout veranderen en changed naar false zetten
        if(changed){
            text.fontSize = (int)Mathf.Floor(lastSize/divider);
            changed = false;
        }
    }
}
