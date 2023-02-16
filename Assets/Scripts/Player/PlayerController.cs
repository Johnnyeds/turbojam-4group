using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rigidbody;
	public float upForce = 10;
	public float downForce = 10;

	Vector3 startPosition;
    void Awake()
    {
		startPosition = rigidbody.transform.position;

	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.W)) {
			rigidbody.AddForce(Vector3.up* upForce, ForceMode.Impulse);
		}

		if (Input.GetKeyDown(KeyCode.S)) {
			rigidbody.AddForce(Vector3.down * downForce, ForceMode.Impulse);
		}
	}
}
