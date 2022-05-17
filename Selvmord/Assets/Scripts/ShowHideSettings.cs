using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideSettings : MonoBehaviour
{
    public Canvas canvasObject;
    public Canvas hideObject;

    void Start()
    {
        canvasObject.enabled = !canvasObject.enabled;
    }

    public void showSettings()
    {
        canvasObject.enabled = !canvasObject.enabled;
        hideObject.enabled = !hideObject.enabled;
    }
}
