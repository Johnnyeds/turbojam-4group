using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHUD : MonoBehaviour {

    public void OnClickReset() {
        GameManager.instance.ResetGame();
    }
}
