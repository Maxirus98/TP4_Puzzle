using UnityEngine;

public class LabyrinthItemHandler : Draggable
{
    private int goalId;
    [SerializeField] private int id;
    private LabyrinthHandler handler;
    private bool onGoal;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        moveSpeed = 150;
        handler = GameObject.Find("Labyrinth").GetComponent<LabyrinthHandler>();
    }

    void Update()
    {
        if(selected)
        {
            OnDrag();
        }
    }

    private void OnDrag()
    {
        var mouseDeltaX = Input.GetAxis("Mouse X");
        var mouseDeltaY = Input.GetAxis("Mouse Y");

        rb.linearVelocity = ((Vector2.right * mouseDeltaX) + (Vector2.up * mouseDeltaY)) * moveSpeed;
    }


    private void OnMouseDown()
    {
        selected = true;
        rb.WakeUp();
    }

    private void OnMouseUp() 
    { 
        selected = false;
        if(!onGoal)
        {
            rb.Sleep();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            onGoal = true;
            var goal = collision.GetComponent<LabyrinthGoalData>();
            goalId = goal.id;
            handler.IncrementSuccessCount(id, goalId);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            onGoal = false;
            handler.DecrementSuccessCount(id, goalId);
            goalId = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Clip to goal
        if(!selected && collision.CompareTag("Goal"))
        {
            transform.position = collision.transform.position;
        }
    }
}
