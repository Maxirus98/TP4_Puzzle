using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject targetPiece; // Le morceau correct à activer une fois bien placé
    public float snapThreshold = 0.5f;
    private Vector3 initialPosition;  // La position initiale du morceau avant le drag

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

        // Assure-toi que le morceau cible est invisible au départ
        targetRenderer.enabled = false;

        // Enregistre la position initiale du morceau
        initialPosition = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPlaced) return;
        transform.Rotate(0f, 0f, -90f); // Tourner de 90° à chaque clic
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlaced) return;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

        // Vérification de la distance et de la rotation
        float distance = Vector2.Distance(transform.position, targetPiece.transform.position);
        float angle = Mathf.Round(transform.eulerAngles.z % 360f);
        float targetAngle = Mathf.Round(targetPiece.transform.eulerAngles.z % 360f);

        // Debug pour suivre ce qui se passe
        Debug.Log($"Drop: {gameObject.name} → Distance: {distance}, Angle: {angle}, TargetAngle: {targetAngle}");

        // Si le morceau est proche du bon endroit et avec la bonne rotation
        if (distance <= snapThreshold && angle == targetAngle)
        {
            Debug.Log($"{gameObject.name} placé avec succès !");
            targetRenderer.enabled = true;    // Affiche le morceau correct
            thisRenderer.enabled = false;     // Cache ce morceau
            isPlaced = true;
        }
        else
        {
            // Si ce n'est pas la bonne position, remettre à la position initiale
            Debug.Log($"{gameObject.name} n'est pas à la bonne position. Réinitialisation...");
            transform.position = initialPosition;
        }
    }
}
