using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampManager : MonoBehaviour
{
    public GameObject objectForYellow;  // Object for yellow lamps
    public GameObject objectForBlue;    // Object for blue lamps

    void Start()
    {
        // Hide objects initially
        objectForYellow.SetActive(false);
        objectForBlue.SetActive(false);
    }

    void Update()
    {
        // If both lamps are yellow, show objectForYellow
        if (Lamp1Color.isLamp1Yellow && Lamp2Color.isLamp2Yellow)
        {
            objectForYellow.SetActive(true);
            objectForBlue.SetActive(false);
        }
        // If both lamps are blue, show objectForBlue
        else if (!Lamp1Color.isLamp1Yellow && !Lamp2Color.isLamp2Yellow)
        {
            objectForYellow.SetActive(false);
            objectForBlue.SetActive(true);
        }
        else
        {
            // If lamps are in any other combination, hide both objects
            objectForYellow.SetActive(false);
            objectForBlue.SetActive(false);
        }
    }
}
