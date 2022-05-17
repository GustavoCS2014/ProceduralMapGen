using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour
{
    public Dropdown dropdown;
    public int quality; 

    // Start is called before the first frame update
    void Start()
    {
        quality = PlayerPrefs.GetInt("typeQuality", 5);
        dropdown.value = quality;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QualityAdjust()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("typeQuality", dropdown.value);
        quality = dropdown.value;
    }
}
