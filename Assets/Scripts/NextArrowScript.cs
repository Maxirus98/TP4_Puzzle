using UnityEngine;

public class NextArrowScript : MonoBehaviour
{
    [SerializeField] private Transform cameraDestTransform;
    [SerializeField] private AudioCaller caller;
    private CameraController controller;
    private SpriteRenderer sr;

    private void Start()
    {
        controller = Camera.main.GetComponent<CameraController>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.black;
    }

    private void OnMouseEnter()
    {
        sr.color = Color.green;
    }

    private void OnMouseExit()
    {
        sr.color = Color.black;
    }

    private void OnMouseDown()
    {
        controller.MoveCameraTo(cameraDestTransform.position);
        caller.PlayClick();
    }
}
