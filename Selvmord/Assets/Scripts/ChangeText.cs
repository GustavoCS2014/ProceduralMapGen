using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public string textValue;
    public Text textElement;

    public void HoverText()
    {
        textElement.text = textValue;
    }
}
