using UnityEngine;

public class LabyrinthItemHandler : Draggable
{
    private int goalId;
    [SerializeField] private int id;
    private LabyrinthHandler handler;
    private bool onGoal;

    private void Start()
    {
        moveSpeed = 150;
        handler = GameObject.Find("Labyrinth").GetComponent<LabyrinthHandler>();
    }

    protected new void OnMouseDown()
    {
        base.OnMouseDown();
        rb.WakeUp();
    }

    protected new void OnMouseUp() 
    { 
        base.OnMouseUp();
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
