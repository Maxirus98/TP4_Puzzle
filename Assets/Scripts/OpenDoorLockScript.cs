using UnityEngine;

public class OpenDoorLockScript : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private GameObject codePorte;

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
        codePorte.SetActive(!codePorte.activeInHierarchy);
    }
}
