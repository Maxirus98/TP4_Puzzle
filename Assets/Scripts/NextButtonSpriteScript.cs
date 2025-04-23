using UnityEngine;

public class NextButtonSpriteScript : MonoBehaviour
{
    [SerializeField] private Transform cameraDestTransform;
    [SerializeField] private AudioCaller caller;

    private SpriteRenderer[] srs;
    private CameraController controller;
    

    void Start()
    {
        srs = transform.GetComponentsInChildren<SpriteRenderer>();
        controller = Camera.main.GetComponent<CameraController>();
    }

    private void OnMouseEnter()
    {
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < srs.Length; i++)
        {
            srs[i].color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        var cameraDest = new Vector3(cameraDestTransform.position.x, cameraDestTransform.position.y, -10);
        controller.transform.position = cameraDest;
        caller.PlayPaper();
    }
}
