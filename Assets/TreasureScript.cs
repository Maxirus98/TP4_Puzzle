using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private SpriteRenderer godRaySr;
    [SerializeField] private Sprite treasureOpen;
    [SerializeField] private GameObject carrot;
    [SerializeField] private AudioCaller caller;
    [SerializeField] private GameObject canvasFin;
    private bool opened = false;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if(!opened)
        {
            godRaySr.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (!opened) { 
            godRaySr.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if(!opened) {
            opened = true;
            sr.enabled = false;
            godRaySr.enabled = true;
            carrot.SetActive(true);
            canvasFin.SetActive(true);
            caller.PlayWin();
            caller.PlayApplause();
        }
    }
}
