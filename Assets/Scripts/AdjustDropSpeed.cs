using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustDropSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickLaunch() {
        GameManager.instance.SetState(GameManager.GameState.Launched);
    }
}
