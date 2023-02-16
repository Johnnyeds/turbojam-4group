using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlobbObject : MonoBehaviour {
    public UnityEvent<Vector3 /* point */, Vector3 /* response momentum */> OnCollideWithFallingObject;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("FallingObject")) {
            var collisionVelocity = collision.relativeVelocity.magnitude;
            foreach (ContactPoint contact in collision.contacts) {
                var responseNormal = new Vector3(contact.normal.x, -contact.normal.y, contact.normal.z);
                var response = responseNormal * collisionVelocity * collision.rigidbody.mass;
                OnCollideWithFallingObject.Invoke(contact.point, response);
            }
        }
    }
}
