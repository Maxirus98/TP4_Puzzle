using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool cameraCanMove = false;
    private Vector3 cameraDestination;
    private Vector3 cameraStartPos;
    
    public void MoveCameraTo(Vector3 cameraDestination)
    {
        cameraCanMove = true;
        cameraStartPos = transform.position;
        transform.position = new Vector3(cameraDestination.x, cameraDestination.y, -10);
    }
}
