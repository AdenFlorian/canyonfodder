using System.Collections;
using UnityEngine;

public class TrackTarget : MonoBehaviour
{
    public Transform positionTarget;
    public Transform rotationTarget;
    public Transform scaleTarget;

    public bool positionTracking = false;
    public bool rotationTracking = false;
    public bool scaleTracking = false;

    private void Start()
    {
    }

    private void LateUpdate()
    {
        if (positionTracking) {
            transform.position = positionTarget.position;
        }
        if (rotationTracking) {
            transform.rotation = rotationTarget.rotation;
        }
        if (scaleTracking) {
            transform.localScale = scaleTarget.localScale;
        }
    }
}