using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFallingObject : MonoBehaviour {
    public Rigidbody rigidbody;

    private Vector3 startPosition;

    private void Awake() {
        startPosition = transform.position;
    }
}
