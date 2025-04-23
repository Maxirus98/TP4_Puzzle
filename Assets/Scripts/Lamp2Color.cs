using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp2Color : MonoBehaviour
{
    public SpriteRenderer lamp2;  // Lamp 2 reference
    public Color color1;
    public Color color2;
    public static bool isLocked = false;
    public AudioSource Sound;

    public static bool isLamp2Yellow = true;  // Static variable to track color state

    void Start()
    {
        lamp2.color = color1;  // Initial color set to yellow
    }

    void OnMouseDown()
    {
        Sound.Play();
        // Toggle color on click
        if (lamp2.color == color1)
        {
            lamp2.color = color2;
            isLamp2Yellow = false;
        }
        else
        {
            lamp2.color = color1;
            isLamp2Yellow = true;
        }

       
    }
}
