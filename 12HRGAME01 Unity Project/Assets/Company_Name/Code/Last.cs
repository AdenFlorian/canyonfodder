using UnityEngine;
using System.Collections;

// Last script to execute each frame
public class Last : MonoBehaviour
{
	void Start ()
	{
		Debug.Log("Last has been started...");
		GameManager.state = GameState.Ready;
	}

	void Update ()
	{

	}
}
