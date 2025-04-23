using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp1Color : MonoBehaviour
{
    public SpriteRenderer lamp1;  // Lamp 1 reference
    public Color color1;
    public Color color2;
    public static bool isLocked = false;
    public AudioSource Sound;
    public static bool isLamp1Yellow = false;  // Static variable to track color state

    void Start()
    {
        lamp1.color = color2;  // Initial color set to yellow
    }

    void OnMouseDown()
    {
        Sound.Play();
        // Toggle color on click
        if (lamp1.color == color1)
        {
            lamp1.color = color2;
            isLamp1Yellow = false;
        }
        else
        {
            lamp1.color = color1;
            isLamp1Yellow = true;
        }

    }
}
