using UnityEngine;

public class LabyrinthHandler : MonoBehaviour
{
    public int SuccessCount = 0;
    private readonly int SUCCESS_COUNT_TO_COMPLETE = 3;
    [SerializeField]private GameObject success;

    
    public void IncrementSuccessCount(int id, int goalId)
    {
        if (id == goalId) { 
            SuccessCount++;
        }

        CheckSuccess();
    }

    public void DecrementSuccessCount(int id, int goalId)
    {
        if (id == goalId)
        {
            SuccessCount--;
        }
    }

    private void CheckSuccess()
    {
        success.SetActive(SuccessCount == SUCCESS_COUNT_TO_COMPLETE);
    }
}
