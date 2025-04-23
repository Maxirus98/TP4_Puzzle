using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCorrect : MonoBehaviour
{
    public Transform objectToMove;      // The object that should move (e.g. player)
    public Transform snapPoint;         // An empty GameObject placed at the center of the platform
    public Transform cameraTarget;        // Where the camera should move to (an empty GameObject below)
    public float cameraMoveSpeed = 2f;    // Speed of camera movement

    private bool moveCamera = false;
    private Camera mainCamera;

    public AudioSource goodSound;
    public GameObject fake1;
    public GameObject fake2;
    public GameObject real;
    public GameObject image1;
    public GameObject image2;

    void Start()
    {
        image2.SetActive(false);
        mainCamera = Camera.main;
    }
    void OnMouseDown()
    {
        if (objectToMove != null && snapPoint != null)
        {
            objectToMove.position = snapPoint.position;
            goodSound.Play();
        }
        fake1.SetActive(false);
        fake2.SetActive(false);
        real.GetComponent<BoxCollider2D>().enabled = false;
        image1.SetActive(false);
        image2.SetActive(true);

        if (cameraTarget != null)
        {
            mainCamera.transform.position = new Vector3(
                    mainCamera.transform.position.x,
                    cameraTarget.position.y,
                    mainCamera.transform.position.z);
        }
    }

   
}
