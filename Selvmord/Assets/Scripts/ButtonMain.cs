using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMain : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip hoverSound;
    
    public void HoverSound()
    {
        mySounds.PlayOneShot(hoverSound);
    }
}
