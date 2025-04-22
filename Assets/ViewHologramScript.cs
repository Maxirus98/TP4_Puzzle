using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ViewHologramScript : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Sprite openEyeSprite;
    [SerializeField] private Sprite closedEyeSprite;
    [SerializeField] private GameObject hologramme;

    private float secondsToWait = 5;
    private bool isEyeOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        sr.color = Color.white;
        sr.sprite = openEyeSprite;
        isEyeOpen = true;
        hologramme.SetActive(true);

        if (isEyeOpen)
        {
            StartCoroutine(nameof(CloseEye));
        }
    }

    private IEnumerator CloseEye()
    {
        yield return new WaitForSeconds(secondsToWait);
        isEyeOpen = false;
        hologramme.SetActive(false);
        sr.sprite = closedEyeSprite;
    }
}
