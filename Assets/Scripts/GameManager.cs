using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public TempFallingObject fallingObject;
    public BlobbObject blobbObject;
    public Character character;

    private bool isReadyToLaunch = true;
    
    public void OnObjectImpact(Vector3 point, Vector3 responseMomentum) {
        if (isReadyToLaunch) {
            character.ApplyMomentum(responseMomentum);
            isReadyToLaunch = false;
        }
    }
}
