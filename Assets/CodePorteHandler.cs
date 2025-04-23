using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Playables;

public class CodePorteHandler : MonoBehaviour
{
    [SerializeField] private ViewHologramScript viewHologramScript;
    [SerializeField] private SpriteRenderer eyeCircle;
    [SerializeField] private SpriteRenderer doorLockRenderer;
    [SerializeField] private SpriteRenderer templeRenderer;
    [SerializeField] private Sprite templeOpenSprite;
    [SerializeField] private Sprite eyeOpenSR;
    [SerializeField] private Sprite eyeCloseSR;
    [SerializeField] private GameObject codePorteIconList;
    [SerializeField] private DoorLockData[] doorLockDataArray;
    [SerializeField] private Transform nextTransform;
    [SerializeField] private PlayableDirector timelineDoor;
    private CameraController controller;
    private readonly char[] GOOD_ANSWER = new char[6] { 's', 'c', 't', 't', 's', 'c' };
    private bool completed = false;

    private void Start()
    {
        controller = Camera.main.GetComponent<CameraController>();
        doorLockDataArray = GetComponentsInChildren<DoorLockData>();
    }

    private void Update()
    {
        CheckAnswer();
    }

    public void CheckAnswer()
    {
        // Do it once
        if (completed)
        {
            controller.MoveCameraTo(nextTransform.position);
            viewHologramScript.gameObject.SetActive(false);
            gameObject.SetActive(false);
            return;
        }

        var goodAnswerCount = 0;

        for (int i = 0;  i < GOOD_ANSWER.Length; i++) 
        {
            if (GOOD_ANSWER[i] == doorLockDataArray[i].Id)
            {
                goodAnswerCount++;
                if (goodAnswerCount == GOOD_ANSWER.Length)
                {
                    completed = true;
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        eyeCircle.color = new Color(0, 1, 0, 0.18f);
    }

    private void OnMouseExit()
    {
        eyeCircle.color = new Color(0, 1, 0, 0f);
    }

    private void OnMouseDown()
    {
        viewHologramScript.ToggleHologram();
        doorLockRenderer.sprite = !viewHologramScript.IsEyeOpen ? eyeOpenSR : eyeCloseSR;
        //codePorteIconList.SetActive(!viewHologramScript.IsEyeOpen);
    }
}
