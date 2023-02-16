using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Character characterPrefab;
    public TempFallingObject fallingObject;
    public BlobbObject blobbObject;
    public Character character;
	public CameraController cameraController;

    private bool isReadyToLaunch = true;
    private static GameManager m_instance;

    private Vector3 characterStartPosition;
    private Quaternion characterStartRotation;
    
    public static GameManager instance {
        get {
            if (m_instance == null) {
                m_instance = FindObjectOfType<GameManager>();
            }

            return m_instance;
        }
    }

    private void Awake() {
        characterStartPosition = character.transform.position;
        characterStartRotation = character.transform.rotation;
    }

    public void OnObjectImpact(Vector3 point, Vector3 responseMomentum) {
        if (isReadyToLaunch) {
            character.ApplyMomentum(responseMomentum);
            isReadyToLaunch = false;
        }
		cameraController.SetState(CameraController.CameraState.FLYING);

	}

    public void ResetGame() {
        fallingObject.Reset();
        
        Destroy(character.gameObject);
        character = Instantiate(characterPrefab, characterStartPosition, characterStartRotation);
        isReadyToLaunch = true;
		//cameraController.ResetCamera(character.transform);
    }
}
