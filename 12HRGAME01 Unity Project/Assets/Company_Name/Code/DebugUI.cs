using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DebugUI : MonoBehaviour
{
	public static DebugUI Instance;

	public List<float> floats = new List<float>();
	public Text text;

	void Start ()
	{
		Instance = this;
	}

	void Update ()
	{
		text.text = "";
	}

	public void Register(ref float fff)
	{
		//floats.Add(fff);
	}
}
