using UnityEngine;

public class DoorLockData : MonoBehaviour
{
    public char Id;
    public SpriteRenderer Sr;

    private void Awake()
    {
        Sr = GetComponent<SpriteRenderer>();
    }
}
