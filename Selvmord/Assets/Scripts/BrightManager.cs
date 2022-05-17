using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightManager : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBright;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("bright", 0.5f);

        panelBright.color = new Color(panelBright.color.r, panelBright.color.g, panelBright.color.b, slider.value);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSlider(float val)
    {
        sliderValue = val;
        PlayerPrefs.SetFloat("bright", sliderValue);
        panelBright.color = new Color(panelBright.color.r, panelBright.color.g, panelBright.color.b, slider.value);
    }
}
