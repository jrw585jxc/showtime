using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{
    private bool jumpWasPressed;
    public Vector2 desiredMovement;
    private Rigidbody rigidBody;
    public FloorDetector floorDetector;
    public Transform cameraTransform;
    public GameObject projectile;

    private Vector3 externalVelocity;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpWasPressed = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }

        desiredMovement.x = Input.GetAxis("Horizontal");
        desiredMovement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (rigidBody == null) return;

        var isTouchingFloor = floorDetector.IsTouchingFloor();

        if (jumpWasPressed && isTouchingFloor)
        {
            var force = new Vector3(0f, 10f, 0f);
            rigidBody.AddForce(force, ForceMode.VelocityChange);
            jumpWasPressed = false;
        }

        var currentVelocity = rigidBody.velocity;
        var localMovement = new Vector3(desiredMovement.x, 0f, desiredMovement.y);
        var newVelocity = 5f * (cameraTransform.rotation * localMovement);
        newVelocity.y = currentVelocity.y;

        rigidBody.velocity = newVelocity + externalVelocity;
        externalVelocity = Vector3.zero;
    }

    public void ApplyExternalForce(Vector3 force)
    {
        externalVelocity += force;
    }

    private void FireProjectile()
    {
        var newProjectile = Instantiate(projectile, null);
        var direction = (transform.position - cameraTransform.position).normalized;

        newProjectile.transform.rotation = cameraTransform.rotation;
        newProjectile.transform.position = 0.5f * direction + transform.position;

        Destroy(newProjectile, 5f);
    }
}
