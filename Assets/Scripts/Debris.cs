using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public int hitsRequired;
    public int currentHits;
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    // This method is called by the UI button
    public void Debriss()
    {


        currentHits++;



        if (currentHits == hitsRequired)
        {
            gameObject.SetActive(true);
        }
    }


}
