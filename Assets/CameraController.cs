using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private bool cameraCanMove = false;
    private Vector3 cameraDestination;
    private Vector3 cameraStartPos;
    
    // Update is called once per frame
    void Update()
    {
        if (cameraCanMove) {
            // transform.position = Vector3.Lerp(cameraStartPos, cameraDestination, 100 * Time.deltaTime);
        }

    }

    public void MoveCameraTo(Vector3 cameraDestination)
    {
        cameraCanMove = true;
        cameraStartPos = transform.position;
        this.cameraDestination = cameraDestination;
    }
}
