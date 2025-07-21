using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCube : MonoBehaviour
{
    public Vector3 pushDirection = Vector3.forward;
    public float pushForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerTemp player = collision.collider.GetComponent<PlayerTemp>(); Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        //if (player != null)
        //{
           //Vector3 force = pushDirection.normalized * pushForce;
            //player.ApplyExternalForce(force);
        //}
    }
}
