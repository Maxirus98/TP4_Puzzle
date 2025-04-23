using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakNoPuzz : MonoBehaviour
{
    public int hitsRequired;
    public int currentHits;
    private bool isBroken = false;

    
   
    

    void Start()
    {
       
    }

    // This method is called by the UI button
    public void ReceiveShockwave()
    {
        if (isBroken) return;

        currentHits++;

       

        if (currentHits >= hitsRequired)
        {
            BreakWall();
        }
    }

    void BreakWall()
    {
        isBroken = true;

       

       

        gameObject.SetActive(false);
    }

}
