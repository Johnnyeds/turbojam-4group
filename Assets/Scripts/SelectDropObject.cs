using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDropObject : MonoBehaviour {
    public TempFallingObject dropObject;

    public void OnClickToggleLeft() {
        GameManager.instance.fallingObject.Toggle(-1);
    }

    public void OnClickToggleRight() {
        GameManager.instance.fallingObject.Toggle(1);
    }

    public void OnClickContinue() {
        GameManager.instance.SetState(GameManager.GameState.AdjustDropSpeed);
    }
}
