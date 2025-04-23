using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    public int hitsRequired;
    public int currentHits;
    private bool isBroken = false;

    public GameObject hiddenPuzzle;
    public AudioSource BreakSound;

    

    void Start()
    {
        if (hiddenPuzzle != null)
        {
            hiddenPuzzle.SetActive(false);
        }
    }

    // This method is called by the UI button
    public void ReceiveShockwave()
    {
        if (isBroken) return;

        currentHits++;

        //if (hitSound != null)
       //     hitSound.Play();

        if (currentHits >= hitsRequired)
        {
            BreakWall();
            
        }
    }

    void BreakWall()
    {
        isBroken = true;


        if (hiddenPuzzle != null)
        {
            hiddenPuzzle.SetActive(true);
        }

       gameObject.SetActive(false);
    }

}   

