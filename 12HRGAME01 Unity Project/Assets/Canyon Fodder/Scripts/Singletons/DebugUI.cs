using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugUI : MonoBehaviour
{
	public static DebugUI Instance;

	public Text text;

	void Start ()
	{
		Instance = this;
	}

	void Update ()
	{
		text.text = "";
	}
}
