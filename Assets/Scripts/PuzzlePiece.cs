using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject targetPiece; // Le morceau correct à activer une fois bien placé
    public float snapThreshold = 0.5f;
    public AudioSource clickSound; // Sound to play on rotation
    public AudioSource placeSound; // ✅ Sound to play when placed correctly

    private Vector3 initialPosition;
    private Vector3 offset;
    private bool isPlaced = false;

    private SpriteRenderer targetRenderer;
    private SpriteRenderer thisRenderer;

    void Start()
    {
        targetRenderer = targetPiece.GetComponent<SpriteRenderer>();
        thisRenderer = GetComponent<SpriteRenderer>();

        if (targetRenderer == null || thisRenderer == null)
        {
            Debug.LogError("Il manque un SpriteRenderer sur un des objets !");
        }

        targetRenderer.enabled = false;
        initialPosition = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPlaced) return;
        thisRenderer.sortingOrder = 1;
        transform.Rotate(0f, 0f, -90f);

        if (clickSound != null)
        {
            clickSound.Play();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlaced) return;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        thisRenderer.sortingOrder = 2;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isPlaced) return;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0f) + offset;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isPlaced) return;
        thisRenderer.sortingOrder = 0;

        float distance = Vector2.Distance(transform.position, targetPiece.transform.position);
        float angle = Mathf.Round(transform.eulerAngles.z % 360f);
        float targetAngle = Mathf.Round(targetPiece.transform.eulerAngles.z % 360f);

        Debug.Log($"Drop: {gameObject.name} → Distance: {distance}, Angle: {angle}, TargetAngle: {targetAngle}");

        if (distance <= snapThreshold && angle == targetAngle)
        {
            Debug.Log($"{gameObject.name} placé avec succès !");
            targetRenderer.enabled = true;
            thisRenderer.enabled = false;
            isPlaced = true;

            // ✅ Play placement sound
            if (placeSound != null)
            {
                placeSound.Play();
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} n'est pas à la bonne position. Réinitialisation...");
            transform.position = initialPosition;
        }
    }
}