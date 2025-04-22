using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MapPuzzleHandler : MonoBehaviour
{
    [SerializeField] private Transform cameraDestTransform;
    public PuzzlePiece[] puzzlePieces;
    private CameraController controller;
    private bool allMapPiecesPlaced = false;

    private void Start()
    {
        controller = Camera.main.GetComponent<CameraController>();
        puzzlePieces = GetComponentsInChildren<PuzzlePiece>();
    }

    public void CheckAllPuzzlePlaced()
    {
        var totalPieces = 7;
        int currentPiecesPlaced = 0;
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i].IsPlaced()) {
                currentPiecesPlaced++;
            }
        }

        Debug.Log($"Current pieces placed {currentPiecesPlaced}");
        if (currentPiecesPlaced == totalPieces) {
            controller.MoveCameraTo(cameraDestTransform.position);
        }
    }
}
