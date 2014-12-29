using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	Vector3 startScale;
	bool isGrounded = false;
	int distance = 0;

	void Start ()
	{
		startScale = transform.localScale;
		rigidbody.isKinematic = true;
	}

	void Update ()
	{
		DebugUI.Instance.text.text += "Projectile Velocity: " + rigidbody.velocity.ToString() + "\n";
		distance = ((int)(transform.position.x * 10));
		DebugUI.Instance.text.text += "Distance: " + distance + "\n";

		if (Physics.Raycast(transform.position, -Vector3.up, 1)) {
			isGrounded = true;
			rigidbody.angularDrag += 2f * Time.deltaTime;
		} else {
			isGrounded = false;
			rigidbody.angularDrag = Mathf.Clamp(rigidbody.angularDrag - (2f * Time.deltaTime), 0.1f, 20f);
		}

		if (GameManager.state == GameState.Flying &&
			isGrounded &&
			rigidbody.velocity.x < 0.2f &&
			rigidbody.velocity.y < 0.2f)
		{
			GameManager.Instance.EndRound();
			GameManager.Instance.scoreManager.LogScore(distance);
		}
	}

	public void Launch(float force)
	{
		transform.parent = null;
		rigidbody.isKinematic = false;
		rigidbody.AddRelativeForce(Vector3.forward * 30 * ((force + 1.1f) * (force + 1.1f)), ForceMode.VelocityChange);
		rigidbody.AddRelativeTorque(0, 0, 1000);
		transform.localScale = startScale;
	}

	public void Stop()
	{
		rigidbody.isKinematic = true;
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		audio.Play();
    }
}
