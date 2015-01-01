using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
    }

    private void Update()
    {
        float x = -1.5f * (1 / (target.transform.position.x * 0.01f + 0.51f));
        float y = -4f - target.transform.position.y * 0.08f;
        float z = 8f + target.transform.position.y * 0.01f;
        transform.position = target.transform.position - new Vector3(x, y, z);
        transform.LookAt(target.transform.position);
    }

    public void Reset()
    {
    }
}