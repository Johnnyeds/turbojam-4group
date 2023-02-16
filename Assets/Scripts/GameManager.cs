using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public TempFallingObject fallingObject;
    public BlobbObject blobbObject;
    public Character character;

    private bool isReadyToLaunch = true;
    private static GameManager m_instance;

    public static GameManager instance {
        get {
            if (m_instance == null) {
                m_instance = FindObjectOfType<GameManager>();
            }

            return m_instance;
        }
    }
    
    public void OnObjectImpact(Vector3 point, Vector3 responseMomentum) {
        if (isReadyToLaunch) {
            character.ApplyMomentum(responseMomentum);
            isReadyToLaunch = false;
        }
    }

    public void ResetGame() {
        
    }
}
