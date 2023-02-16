using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private Rigidbody[] rigidBodies;

    private void Awake() {
        rigidBodies = gameObject.GetComponentsInChildren<Rigidbody>();
    }

    public void ApplyMomentum(Vector3 momentum) {
        foreach (var rigidbody in rigidBodies) {
            rigidbody.velocity += (1f / rigidbody.mass) * momentum;
        }
    }
}
