using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	CannonState state;
	AnimationState animPivot;
	AnimationState animStretch;

	public Projectile projectile;

	public AudioClip clipPivoting;
	public AudioClip clipLaunch;

	public void Start ()
	{
		animPivot = animation["cannon_pivot"];
		animStretch = animation["cannon_stretch"];
	}

	void Update ()
	{
		DebugUI.Instance.text.text += "CannonState: " + state.ToString() + "\n";
		AdjustAudio();
	}

	public void StartPivoting()
	{
		if (state != CannonState.Stopped)
		{
			Debug.LogError("Can't StartPivoting unless Stopped!");
		}
		animation.Play("cannon_pivot", PlayMode.StopAll);
		animPivot.speed = 1.3f;
		audio.clip = clipPivoting;
		audio.loop = true;
		audio.Play();
		state = CannonState.Pivoting;
	}

	public void StartStretching()
	{
		if (state != CannonState.Pivoting)
		{
			Debug.LogError("Can't StartStretching unless Pivoting!");
		}
		animation.Play("cannon_stretch", PlayMode.StopAll);
		animStretch.speed = 1.1f;
		state = CannonState.Stretching;
	}

	public void Stop()
	{
		if (state != CannonState.Stretching)
		{
			Debug.LogError("Can't Stop unless Stretching!");
		}
		animation.Stop();
		state = CannonState.Stopped;
	}

	public void NextState()
	{
		switch (state)
		{
			case CannonState.Stopped:
				StartPivoting();
				break;
			case CannonState.Pivoting:
				StartStretching();
				break;
			case CannonState.Stretching:
				projectile.Launch((Mathf.Sin(animStretch.normalizedTime * Mathf.PI * 2f + Mathf.PI * 1.5f) * 0.5f) + 0.5f);
				audio.loop = false;
				audio.clip = clipLaunch;
				audio.Play();
				GameManager.state = GameState.Flying;
				Stop();
				break;
		}
	}

	public void AdjustAudio()
	{
		switch (state)
		{
			case CannonState.Stopped:
				//audio.Stop();
				break;
			case CannonState.Pivoting:
				audio.pitch = 1f + (Mathf.Sin(animPivot.normalizedTime * Mathf.PI * 2f + Mathf.PI * 1.5f) * 0.5f) + 0.5f;
				break;
			case CannonState.Stretching:
				audio.pitch = 1f + (Mathf.Sin(animStretch.normalizedTime * Mathf.PI * 2f + Mathf.PI * 1.5f) * 0.5f) + 0.5f;
				break;
		}
	}
}

enum CannonState
{
	Stopped,
	Pivoting,
	Stretching
}
