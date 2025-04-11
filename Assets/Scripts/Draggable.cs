using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    protected bool selected;
    protected Rigidbody2D rb;
    [SerializeField] protected float moveSpeed;
}
