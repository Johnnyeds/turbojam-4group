using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
	public Transform targetObject;
	public Vector3 Offset;
	public float distance;
	public float cameraSpeed = 10.0f;

    void Start()
    {
    }

    void LateUpdate()
    {
		Offset = Offset.normalized;
		Vector3 currentOffset = Offset * distance;

		Vector3 targetPosition = targetObject.transform.position + currentOffset;
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
		transform.rotation = Quaternion.LookRotation(targetObject.transform.position - transform.position, Vector3.up);
	}
}
