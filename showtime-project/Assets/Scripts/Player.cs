using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 desiredMovement;
    public bool jumpPressed;
    private Animator animator;
    public FloorDetector floorDetector;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

        // desiredMovement has 2 directions, X and Y, for horizontal and vertical
        desiredMovement.x = Input.GetAxis("Horizontal");
        desiredMovement.y = Input.GetAxis("Vertical");
    }

    // FixedUpdate is called once per fixed frame
    private void FixedUpdate()
    {
        animator.SetBool("isMoving", desiredMovement.magnitude > 0);
    }
}