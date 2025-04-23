using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ViewHologramScript : MonoBehaviour
{
    public bool IsEyeOpen = false;

    private SpriteRenderer sr;
    [SerializeField] private Sprite openEyeSprite;
    [SerializeField] private Sprite closedEyeSprite;

    void Start()
    {
        // Sr du parent
        gameObject.SetActive(false);
        sr = GetComponentInParent<SpriteRenderer>();
    }

    public void ToggleHologram()
    {
        if (IsEyeOpen)
        {
            IsEyeOpen = false;
            gameObject.SetActive(false);
            sr.sprite = closedEyeSprite;
        } else
        {
            sr.color = Color.white;
            sr.sprite = openEyeSprite;
            IsEyeOpen = true;
            gameObject.SetActive(true);
        }
    }
}
