using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFallingObject : MonoBehaviour {
    public Rigidbody rigidbody;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake() {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void Reset() {
        transform.position = startPosition;
        transform.rotation = startRotation;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
}
