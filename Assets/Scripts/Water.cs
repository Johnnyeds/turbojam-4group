using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	public float BuoyancyForce = 100.0f;

	private BoxCollider collider;

	private void Awake() {
		collider = GetComponent<BoxCollider>();
	}

	private void OnTriggerEnter(Collider other) {
		var character = other.gameObject.GetComponentInParent<Character>();
		if (character != null)
			character.OnWaterCollision();
	}
}
