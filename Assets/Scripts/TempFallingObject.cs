using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFallingObject : MonoBehaviour {
    [Serializable]
    public struct DropObject {
        public GameObject root;
        public float weight;
    }
    
    public Rigidbody rigidbody;

    public DropObject[] dropObjects;

    private int currentIndex = 0;
    
    public void Reset(Vector3 position, Quaternion rotation) {
        transform.position = position;
        transform.rotation = rotation;
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
            dropObject.root.SetActive(i == currentIndex);
            if (i == currentIndex) {
                rigidbody.mass = dropObject.weight;
            }
        }
    }
}
