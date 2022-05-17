using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSettings : MonoBehaviour
{
    public Canvas canvasObject;
    public Canvas hideObject;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && hideObject.enabled == true)
        {
            canvasObject.enabled = !canvasObject.enabled;
            hideObject.enabled = !hideObject.enabled;
        }
    }
}
