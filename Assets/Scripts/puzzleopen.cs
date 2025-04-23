using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleopen : MonoBehaviour
{
    public string puzzleSceneName = "DEJtest"; // Set this in the Inspector if you want
  
    void Start()
    {
        
    }

    
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadPuzzle();
        }
    }

    void LoadPuzzle()
    {
        SceneManager.LoadScene(puzzleSceneName); // ✅ Use the variable correctly
    }
}
