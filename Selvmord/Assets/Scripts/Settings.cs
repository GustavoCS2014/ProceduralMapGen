using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Color wantedColorOff;
    public Color wantedColorOn;
    public Button off;
    public Button on;

    public void turnOff()
    {
        // Button Off
        ColorBlock cbOff = off.colors;
        cbOff.normalColor = wantedColorOff;
        cbOff.highlightedColor = wantedColorOff;
        cbOff.pressedColor = wantedColorOff;
        off.colors = cbOff;

        // Button On
        ColorBlock cbOn = on.colors;
        cbOn.normalColor = wantedColorOn;
        cbOn.highlightedColor = wantedColorOff;
        cbOn.pressedColor = wantedColorOn;
        on.colors = cbOn;
    }

    public void turnOn()
    {
        // Button On
        ColorBlock cbOn = on.colors;
        cbOn.normalColor = wantedColorOff;
        cbOn.highlightedColor = wantedColorOff;
        cbOn.pressedColor = wantedColorOff;
        on.colors = cbOn;

        // Button On
        ColorBlock cbOff = off.colors;
        cbOff.normalColor = wantedColorOn;
        cbOff.highlightedColor = wantedColorOn;
        cbOff.pressedColor = wantedColorOn;
        off.colors = cbOff;
    }
}
