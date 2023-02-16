using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFallingObject : MonoBehaviour {
    public Rigidbody[] dropObjects;
    public Rigidbody rigidbody => dropObjects[currentIndex];
    
    private int currentIndex = 0;

    private void Awake() {
        Toggle(UnityEngine.Random.Range(0, dropObjects.Length));
    }

    public void Reset() {
        rigidbody.transform.localPosition = Vector3.zero;
        rigidbody.transform.localRotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    public void SetKinematic(bool isKinematic) {
        rigidbody.isKinematic = isKinematic;
    }

    public void Toggle(int steps) {
        currentIndex += steps;
        if (currentIndex >= dropObjects.Length) currentIndex -= dropObjects.Length;
        if (currentIndex < 0) currentIndex += dropObjects.Length;

        for (int i = 0; i < dropObjects.Length; i++) {
            var dropObject = dropObjects[i];
            dropObject.gameObject.SetActive(i == currentIndex);
        }
        
        rigidbody.transform.localPosition = Vector3.zero;
        rigidbody.transform.localRotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
    }
}
