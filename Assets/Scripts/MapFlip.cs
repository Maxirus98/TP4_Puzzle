using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MapFlip : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private GameObject mapFront;
    [SerializeField] private GameObject mapBack;
    [SerializeField] private AudioCaller caller;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        sr.color = Color.white;
    }

    private void OnMouseEnter()
    {
        sr.color = Color.black;
    }

    private void OnMouseExit()
    {
        sr.color = Color.white;
    }

    private void OnMouseDown()
    {
        mapFront.SetActive(!mapFront.activeInHierarchy);
        mapBack.SetActive(!mapBack.activeInHierarchy);

        caller.PlayClick();
    }
}
