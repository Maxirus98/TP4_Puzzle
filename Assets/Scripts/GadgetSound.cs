using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetSound : MonoBehaviour
{
    public AudioSource warpSound;
    public int currentHits;
    public int hitsRequired;

    // Start is called before the first frame update
    void Start()
    {
        warpSound = GetComponent<AudioSource>();

        warpSound.enabled = true;
    }
    public void Sound()
    {
        currentHits++;

       

        // Check if the required number of hits has been reached to break the wall
        if (currentHits > hitsRequired)
        {
            warpSound.enabled = false;
        }




        if (warpSound != null)
        {
           warpSound.Play();
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
