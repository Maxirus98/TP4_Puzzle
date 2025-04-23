using UnityEngine;

public class PlatformIncorrect : MonoBehaviour
{

    public AudioSource wrongSound;

    void OnMouseDown()
    {
        wrongSound.Play();
    }
}
