using System.Collections;
using UnityEngine;

// Last script to execute each frame
public class Last : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Last has been started...");
        GameManager.state = GameState.MainMenu;
    }

    private void Update()
    {
    }
}