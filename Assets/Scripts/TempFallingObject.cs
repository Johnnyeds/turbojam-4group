using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFallingObject : MonoBehaviour {
    public Rigidbody rigidbody;

    public void Reset(Vector3 position, Quaternion rotation) {
        transform.position = position;
        transform.rotation = rotation;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    public void SetKinematic(bool isKinematic) {
        rigidbody.isKinematic = isKinematic;
    }

    public void Toggle(int steps) {
        
    }
}
