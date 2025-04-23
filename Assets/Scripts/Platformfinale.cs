using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformfinale : MonoBehaviour
{
    public Transform objectToMove;      // The object that should move (e.g. player)
    public Transform snapPoint;         // An empty GameObject placed at the center of the platform
    public Transform cameraTarget;        // Where the camera should move to (an empty GameObject below)
    public float cameraMoveSpeed = 2f;    // Speed of camera movement

    private bool moveCamera = false;
    private Camera mainCamera;

    public AudioSource goodSound;
   
    public GameObject real;

    private CameraController controller;
    private bool canMoveCamera = true;
    [SerializeField] private Transform nextTransform;

    void Start()
    {
        mainCamera = Camera.main;
        controller = mainCamera.GetComponent<CameraController>();
    }
    void OnMouseDown()
    {
        if (objectToMove != null && snapPoint != null)
        {
            objectToMove.position = snapPoint.position;
            goodSound.Play();
        }
       
        real.GetComponent<BoxCollider2D>().enabled = false;
       

        if (cameraTarget != null)
        {
            moveCamera = true;
        }

        StartCoroutine(nameof(GoNext));
    }

    private IEnumerator GoNext()
    {
        yield return new WaitForSeconds(1);
        controller.MoveCameraTo(nextTransform.position);
        enabled = false;
    }

    void Update()
    {
        if (moveCamera && mainCamera != null && cameraTarget != null)
        {
            // Smoothly move the camera toward the target position
            mainCamera.transform.position = Vector3.Lerp(
                mainCamera.transform.position,
                new Vector3(
                    mainCamera.transform.position.x,
                    cameraTarget.position.y,
                    mainCamera.transform.position.z
                ),
                Time.deltaTime * cameraMoveSpeed
            );

            // Optional: Stop moving when close enough
            if (Mathf.Abs(mainCamera.transform.position.y - cameraTarget.position.y) < 0.01f)
            {
                moveCamera = false;
            }
        }
    }
}
