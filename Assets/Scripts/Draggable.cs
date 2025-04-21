using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    public bool selected;
    protected Rigidbody2D rb;
    [SerializeField] protected float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if (selected)
        {
            OnDrag();
        }
    }

    protected void OnDrag()
    {
        var mouseDeltaX = Input.GetAxis("Mouse X");
        var mouseDeltaY = Input.GetAxis("Mouse Y");

        rb.linearVelocity = ((Vector2.right * mouseDeltaX) + (Vector2.up * mouseDeltaY)) * moveSpeed;
    }

    protected void OnMouseDown()
    {
        selected = true;
    }

    protected void OnMouseUp()
    {
        selected = false;
    }
}
