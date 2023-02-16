using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Rigidbody rigidbody;
	public float upForce = 10;
	public float downForce = 10;
	private Character character = null;


	private Rigidbody[] rigidbodies;
	Vector3 startPosition;
	void Awake() {
		startPosition = rigidbody.transform.position;
		rigidbodies = GetComponentsInChildren<Rigidbody>();
		character = GetComponent<Character>();
	}

	private void ApplyForce(Vector3 force) {
		for (int i = 0; i < rigidbodies.Length; i++)
			rigidbodies[i].AddForce(force * (1.0f / rigidbodies.Length), ForceMode.Impulse);
	}

	void Update() {
		if (character.isAlive == false)
			return;

		if (Input.GetKeyDown(KeyCode.W)) {
			ApplyForce(Vector3.up * upForce);
		}

		if (Input.GetKeyDown(KeyCode.S)) {
			ApplyForce(Vector3.down * downForce);
		}
	}
}
