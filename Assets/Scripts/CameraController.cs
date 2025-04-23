using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool cameraCanMove = false;
    private Vector3 cameraDestination;
    private Vector3 cameraStartPos;

    [SerializeField] private GameObject doorLock;
    [SerializeField] private GameObject doorLockHolo;


    private void Update()
    {
        if(doorLock.activeInHierarchy || doorLockHolo.activeInHierarchy) {
            Camera.main.orthographicSize = 4;
        }
        else {
            Camera.main.orthographicSize = 2.7f;
        }

    }

    public void MoveCameraTo(Vector3 cameraDestination)
    {
        cameraCanMove = true;
        cameraStartPos = transform.position;
        transform.position = new Vector3(cameraDestination.x, cameraDestination.y, -10);
    }

    public void SetCameraSize(float size)
    {
        Camera.main.orthographicSize = size;
    }
}
