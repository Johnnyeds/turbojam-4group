using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
	public enum CameraState { 
		UNINITIALIZED,
		SELECT_OBJECT,
		PREPARE_LAUNCH,
		FLYING,
		GAME_OVER
	}

	public Transform player;
	public Transform dropObject;
	public Vector3 Offset;
	public float distance;
	public float cameraPanSpeed = 10.0f;
	public float cameraRotateSpeed = 10.0f;
	private float stateTimer = 0.0f;

	public CameraState nextState = CameraState.UNINITIALIZED;

	private CameraState currentState = CameraState.UNINITIALIZED;
	private Vector3 currentLookAt;
	
	public void SetState(CameraState cameraState) {
		nextState = cameraState;
		currentState = cameraState;
		stateTimer = 0.0f;
	}

	public void ResetCamera(Transform playerTransform, Transform dropObj) {
		dropObject = dropObj;
		player = playerTransform.Find("J_Pelvis");
		Snapp();
	}

	private Vector3 GetTargetPosition() {
		Offset = Offset.normalized;
		switch (currentState) {
			case CameraState.UNINITIALIZED:
				return transform.position;
			case CameraState.SELECT_OBJECT:
				return dropObject.position + Offset * distance;
			case CameraState.PREPARE_LAUNCH:
				return ((dropObject.position + player.position) / 2.0f) + Offset * distance*3;
			case CameraState.FLYING:
				return player.position + Offset * distance;
			case CameraState.GAME_OVER:
				return transform.position;
			default:
				return transform.position;
		}
	}

	private Vector3 GetTargetLookAt() {

		switch (currentState) {
			case CameraState.UNINITIALIZED:
				return transform.position + transform.forward;
			case CameraState.SELECT_OBJECT:
				return dropObject.position;
			case CameraState.PREPARE_LAUNCH:
				return ((dropObject.position + player.position) / 2.0f);
			case CameraState.FLYING:
				return player.position;
			case CameraState.GAME_OVER:
				return transform.position + transform.forward;
			default:
				return transform.position + transform.forward;
		}
	}

	private float GetPanSpeed() {
		return (cameraPanSpeed * (currentState == CameraState.FLYING ? Mathf.Lerp(1, 4.0f, stateTimer) : 1.0f)) * Mathf.Min(stateTimer*2.0f, 1.0f);
	}

	private float GetRotateSpeed() {
		return (cameraRotateSpeed * (currentState == CameraState.FLYING ? Mathf.Lerp(1, 10.0f, stateTimer) : 1.0f)) * Mathf.Min(stateTimer * 2.0f, 1.0f); ;
	}

	private void Snapp() {
		transform.position = GetTargetPosition();
		currentLookAt = GetTargetLookAt();
		transform.rotation = Quaternion.LookRotation(currentLookAt - transform.position, Vector3.up);
	}

	private void Update() {
		if (nextState != currentState)
			SetState(nextState);
	}

	void FixedUpdate()
    {
		Vector3 targetPosition = GetTargetPosition();
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * GetPanSpeed());

		currentLookAt = Vector3.MoveTowards(currentLookAt, GetTargetLookAt(), Time.deltaTime * GetRotateSpeed());
		transform.rotation = Quaternion.LookRotation(currentLookAt - transform.position, Vector3.up);

		stateTimer += Time.deltaTime;
	}
}
