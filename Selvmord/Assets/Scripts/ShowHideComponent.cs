using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideComponent : MonoBehaviour
{
    public Canvas canvasObject;
    public Canvas canvasSettings;

    void Start()
    {
        canvasObject = GetComponent<Canvas>();
        canvasObject.enabled = !canvasObject.enabled;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && canvasSettings.enabled == false)
        {
            canvasObject.enabled = !canvasObject.enabled;
        }
    }
}
