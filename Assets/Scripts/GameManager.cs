using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameState {
        SelectDropObject,
        AdjustDropSpeed,
        Launched
    }
    
    public Character characterPrefab;
    public TempFallingObject fallingObject;
    public BlobbObject blobbObject;
    public Character character;
	public CameraController cameraController;
    public GameHUD gameHUD;
    
    private bool isReadyToLaunch = true;
    private static GameManager m_instance;

    private Vector3 characterStartPosition;
    private Quaternion characterStartRotation;
    
    private Vector3 fallingObjectStartPosition;
    private Quaternion fallingObjectStartRotation;
    
    public GameState currentState = GameState.SelectDropObject;
    
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
        
        fallingObjectStartPosition = fallingObject.transform.position;
        fallingObjectStartRotation = fallingObject.transform.rotation;
        SetState(GameState.SelectDropObject);
    }

    public void OnObjectImpact(Vector3 point, Vector3 responseMomentum) {
        if (isReadyToLaunch) {
            character.ApplyMomentum(responseMomentum);
            isReadyToLaunch = false;
        }
		cameraController.SetState(CameraController.CameraState.FLYING);

	}

    public void ResetGame() {
        fallingObject.Reset(fallingObjectStartPosition, fallingObjectStartRotation);
        
        Destroy(character.gameObject);
        character = Instantiate(characterPrefab, characterStartPosition, characterStartRotation);
        isReadyToLaunch = true;
		//cameraController.ResetCamera(character.transform);
    }

    public void SetState(GameState state) {
        switch (state) {
            case GameState.SelectDropObject:
                InitSelectDropObjectState();
                break;
            case GameState.AdjustDropSpeed:
                InitAdjustDropSpeedState();
                break;
            case GameState.Launched:
                InitLaunchedState();
                break;
        }
    }

    private void InitSelectDropObjectState() {
        ResetGame();
        fallingObject.SetKinematic(true);
        character.SetKinematic(true);
        gameHUD.ShowScreen(gameHUD.selectDropObjectScreen);
    }
    
    private void InitAdjustDropSpeedState() {
        gameHUD.ShowScreen(gameHUD.adjustDropSpeedScreen);
    }
    
    private void InitLaunchedState() {
        fallingObject.SetKinematic(false);
        character.SetKinematic(false);
        gameHUD.ShowScreen(gameHUD.launchedScreen);
    }
}
