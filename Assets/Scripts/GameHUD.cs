using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHUD : MonoBehaviour {
    public GameObject selectDropObjectScreen;
    public GameObject adjustDropSpeedScreen;
    public GameObject launchedScreen;
    
    public void ShowScreen(GameObject screen) {
        selectDropObjectScreen.SetActive(screen == selectDropObjectScreen);
        adjustDropSpeedScreen.SetActive(screen == adjustDropSpeedScreen);
        launchedScreen.SetActive(screen == launchedScreen);
    }
}
