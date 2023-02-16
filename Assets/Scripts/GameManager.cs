using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public TempFallingObject fallingObject;
    public BlobbObject blobbObject;
    public Character character;
    
    public void OnObjectImpact(Vector3 point, Vector3 responseMomentum) {
        character.ApplyMomentum(responseMomentum);
    }
}
