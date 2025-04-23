using UnityEngine;

public class NextDoorOpenScript : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Transform nextTransform;
    private CameraController controller;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        controller = Camera.main.GetComponent<CameraController>();
    }

    private void OnMouseEnter()
    {
        sr.color = Color.green;
    }

    private void OnMouseExit()
    {
        sr.color = Color.white;
    }

    private void OnMouseDown()
    {
        controller.MoveCameraTo(nextTransform.position);
        transform.parent.gameObject.SetActive(false);
        nextTransform.parent.gameObject.SetActive(true);
    }
}
