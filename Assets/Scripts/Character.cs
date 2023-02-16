using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private Rigidbody[] rigidBodies;
	public bool isAlive = true;

	public bool isDead { get { return isAlive == false; } }

    private void Awake() {
        rigidBodies = gameObject.GetComponentsInChildren<Rigidbody>();
    }

    public void ApplyMomentum(Vector3 momentum) {
        foreach (var rigidbody in rigidBodies) {
            rigidbody.velocity += (1f / rigidbody.mass) * momentum;
        }
    }
    
    public void SetKinematic(bool isKinematic) {
        foreach (var rigidbody in rigidBodies) {
            rigidbody.isKinematic = isKinematic;
        }
    }
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer("Water")) { 
			isAlive = false;
			foreach (var rigidbody in rigidBodies) {
				rigidbody.velocity = Vector3.zero;
			}
		}
	}

	public void OnWaterCollision() {
		isAlive = false;
		foreach (var rigidbody in rigidBodies) {
			rigidbody.velocity = Vector3.zero;
		}
	}
}
