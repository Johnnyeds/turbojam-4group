using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustDropSpeed : MonoBehaviour {
    public Camera camera;

    public RectTransform arrowRoot;
    
    // Update is called once per frame
    void Update() {
        var dropObjScreenPos = camera.WorldToScreenPoint(GameManager.instance.fallingObject.transform.position);
        arrowRoot.anchoredPosition = dropObjScreenPos;
        
        if (!Input.GetMouseButton(0)) return;

        var mousePosition = Input.mousePosition;
        if (mousePosition.x > 2f * Screen.width / 3f) return;
        
        var aimVector = mousePosition - dropObjScreenPos;
        var angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
        var size = arrowRoot.sizeDelta;
        size.x = aimVector.magnitude;
        arrowRoot.sizeDelta = size;
        arrowRoot.rotation = Quaternion.Euler(0f, 0f, angle);

        GameManager.instance.launchSpeed = new Vector3(aimVector.x / Screen.width, aimVector.y / Screen.height, 0f);
    }
    
    public void OnClickLaunch() {
        GameManager.instance.SetState(GameManager.GameState.Launched);
    }
}
