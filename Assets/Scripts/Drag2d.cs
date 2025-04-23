using UnityEngine;

public class Drag2d : MonoBehaviour
{
    private float offsetX;
    private bool dragging = false;
    public float minX = -3f;
    public float maxX = 0f;
    public GameObject Plantetriste;
    public GameObject Plantecontente;
    public GameObject Bridge;
    public GameObject Perso;
    public GameObject NewPerso;
    public GameObject Lamp1fix;
    public GameObject Lamp2fix;
    public GameObject Lamp1;
    public GameObject Lamp2;
    public AudioSource Succesfull;

    [SerializeField] private Transform nextTransform;
    [SerializeField] private GameObject wallPuzzle;
    private CameraController cameraController;
    private Collider2D col;

    private Vector3 offset;

    private void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        col = GetComponent<Collider2D>();
        Plantetriste.SetActive(true);
        Plantecontente.SetActive(false);

    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        // Only allow dragging if both lamps are yellow
        if (Lamp1Color.isLamp1Yellow && Lamp2Color.isLamp2Yellow)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offsetX = transform.position.x - mousePosition.x;
            dragging = true;

        }
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float newX = Mathf.Clamp(mousePosition.x + offsetX, minX, maxX);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

        if ( transform.localPosition.x <= minX)
        {
            Plantetriste.SetActive(false);
            Plantecontente.SetActive(true);
            Bridge.SetActive(true);
            Perso.SetActive(false);
            NewPerso.SetActive(true);
            Lamp1.SetActive(false);
            Lamp2.SetActive(false);
            Lamp1fix.SetActive(true);
            Lamp2fix.SetActive(true);
            col.enabled = false;
            cameraController.MoveCameraTo(nextTransform.position);
            wallPuzzle.SetActive(false);
        }    
        else
        {
            Plantetriste.SetActive(true);
            Plantecontente.SetActive(false);
            Bridge.SetActive(false);
            Perso.SetActive(true);
            NewPerso.SetActive(false);
            Lamp1fix.SetActive(false);
            Lamp2fix.SetActive(false);
            Lamp1.SetActive(true);
            Lamp2.SetActive(true);
            Succesfull.Play();
            col.enabled = true;
        }
    }
}
