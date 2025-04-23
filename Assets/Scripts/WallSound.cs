using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSound : MonoBehaviour
{      
    public AudioSource hitSound;
    public int currentHits;
    public int hitsRequired;
    public AudioClip breakSound;
    private CameraController controller;
    [SerializeField]private Transform nextTransform;

    // Start is called before the first frame update
    void Start()
    {
        controller = Camera.main.GetComponent<CameraController>();
        hitSound = GetComponent<AudioSource>();

        hitSound.enabled = true;
    }

   public void Sound()
    {
        currentHits++;

        if (currentHits == 4)
        {
            hitSound.PlayOneShot(breakSound);
            controller.MoveCameraTo(nextTransform.position);
        }

        // Check if the required number of hits has been reached to break the wall
        if (currentHits > hitsRequired)
        {
            if (hitSound.isPlaying)
            {
                hitSound.clip=null;
            }
        }
        
        if (hitSound != null)
        {
            hitSound.Play();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
