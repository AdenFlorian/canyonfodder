using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Projectile Instance { get; private set; }

    private Vector3 startScale;
    public bool isGrounded = false;

    public int distance { get; private set; }

    public GameObject projectileSlot;
    private float startAngleDrag;

    private void Awake()
    {
        distance = 0;
        Instance = this;
    }

    private void Start()
    {
        startScale = transform.localScale;
        startAngleDrag = rigidbody.angularDrag;
        rigidbody.isKinematic = true;
        GameManager.Instance.setCameraTarget(gameObject);
    }

    private void Update()
    {
        DebugUI.Instance.text.text += "Projectile Velocity: " + rigidbody.velocity.ToString() + "\n";
        distance = ((int)(transform.position.x * 10));
        distance = distance < 150 ? 0 : distance;
        DebugUI.Instance.text.text += "Distance: " + distance + "\n";

        //Debug.DrawRay(transform.position, -Vector3.up * 1f, Color.magenta, 1f);

        if (Physics.Raycast(transform.position, -Vector3.up, 1f)) {
            //isGrounded = true;
            rigidbody.angularDrag += 2f * Time.deltaTime;
        } else {
            //isGrounded = false;
            rigidbody.angularDrag = Mathf.Clamp(rigidbody.angularDrag - (2f * Time.deltaTime), 0.1f, 20f);
        }

        if (GameManager.state == GameState.Flying &&
            isGrounded &&
            rigidbody.velocity.x < 0.2f &&
            rigidbody.velocity.x > -0.2f &&
            rigidbody.velocity.y < 0.2f &&
            rigidbody.velocity.y > -0.2f) {
            GameManager.Instance.EndRound();
            GameManager.Instance.scoreManager.LogScore(distance);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = false;
    }

    public void Launch(float force)
    {
        transform.parent = null;
        rigidbody.isKinematic = false;
        rigidbody.AddRelativeForce(Vector3.forward * 30 * ((force + 1.1f) * (force + 1.1f)), ForceMode.VelocityChange);
        rigidbody.AddRelativeTorque(0, 0, 1000);
        //transform.localScale = startScale;
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void Stop()
    {
        rigidbody.isKinematic = true;
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnCollisionEnter()
    {
        audio.Play();
    }

    public void Reset()
    {
        GameManager.Instance.cannon.LoadCannon(this);
        transform.localScale = startScale;
        rigidbody.angularDrag = startAngleDrag;
    }
}