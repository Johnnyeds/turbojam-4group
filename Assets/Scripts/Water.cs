using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuoyancy : MonoBehaviour
{
	public float BuoyancyForce = 100.0f;

	private BoxCollider collider;

	private void Awake() {
		collider = GetComponent<BoxCollider>();
	}

	/*	private void OnTriggerStay(Collider other) {

			var otherCollider = other.gameObject.GetComponent<Collider>();
			if (otherCollider == null)
				return;

			Vector3 outDir;
			float outDistance;
			bool overlapped = Physics.ComputePenetration(
						collider, transform.position, transform.rotation,
						otherCollider, other.transform.position, other.transform.rotation,
						out outDir, out outDistance
					);

			if (overlapped) {
				//	other.attachedRigidbody.AddForce(-outDir * outDistance * BuoyancyForce, ForceMode.Force);
			}

		//	other.ClosestPoint
		//	other.attach*edRigidbody.tra
		}*/

	private void OnTriggerEnter(Collider other) {
		Debug.LogError("SPLASH!!");
		var character = other.gameObject.GetComponentInParent<Character>();
		if (character != null)
			character.OnWaterCollision();


	}

	private void OnTriggerExit(Collider other) {
	//	other.attachedRigidbody.useGravity = true;
	}
}
