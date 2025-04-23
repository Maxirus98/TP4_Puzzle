using NUnit.Framework;
using UnityEngine;

public class CodePorteClicker : MonoBehaviour
{
    [SerializeField] private Sprite square;
    [SerializeField] private Sprite circle;
    [SerializeField] private Sprite triangle;

    [SerializeField] private CodePorteHandler handler;
    [SerializeField] private DoorLockData doorLockLink;

    private SpriteRenderer sr;
    [SerializeField] char defaultId;
    public char id;

   

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        id = defaultId;
    }

    private void OnMouseEnter()
    {
        sr.color = Color.green;
    }

    private void OnMouseExit()
    {
        sr.color = Color.white;
    }

    private void OnMouseDown()
    {
        CycleHoloIcons();
    }

    private void CycleHoloIcons()
    {
        if (sr.sprite == square)
        {
            sr.sprite = circle;
            doorLockLink.Sr.sprite = square;
            doorLockLink.Id = 's';
            id = 'c';
        }
        else if (sr.sprite == circle)
        {
            sr.sprite = triangle;
            id = 't';
            doorLockLink.Id = 'c';
            doorLockLink.Sr.sprite = circle;
        }
        else if (sr.sprite == triangle) 
        { 
            sr.sprite = square;
            doorLockLink.Sr.sprite = triangle;
            doorLockLink.Id = 't';
            id = 's';
        }
    }
}
