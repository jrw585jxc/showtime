using UnityEngine;

public class StiltController : MonoBehaviour
{
    public Rigidbody stiltL;
    public Rigidbody stiltR;
    public Camera cam;

    public float moveSpeed = 2f;
    public float rotateSpeed = 50f;
    public float swingAmount = 30f; // Max degrees to swing like a leg
    public float rotationSmooth = 10f;

    private bool leftHeld = false;
    private bool rightHeld = false;

    void Update()
    {
        leftHeld = Input.GetMouseButton(0);
        rightHeld = Input.GetMouseButton(1);
    }

    void FixedUpdate()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (leftHeld && rightHeld)
        {
            // Jump forward with both
            MoveStilt(stiltL, mouseInput, true);
            MoveStilt(stiltR, mouseInput, true);
        }
        else if (leftHeld)
        {
            MoveStilt(stiltL, mouseInput, false);
        }
        else if (rightHeld)
        {
            MoveStilt(stiltR, mouseInput, false);
        }
    }

    void MoveStilt(Rigidbody stilt, Vector2 mouseInput, bool jumpMode)
    {
        Vector3 inputDir = new Vector3(mouseInput.x, 0f, mouseInput.y);
        Vector3 moveDir = cam.transform.TransformDirection(inputDir);
        moveDir.y = 0f;

        if (jumpMode)
        {
            // Apply small forward lunge for jumping
            moveDir = cam.transform.forward * 0.5f;
        }

        // Move the stilt
        stilt.MovePosition(stilt.position + moveDir * moveSpeed * Time.fixedDeltaTime);

        // Rotation: yaw and swing
        float forwardAmount = Vector3.Dot(moveDir.normalized, cam.transform.forward);
        float swingAngle = -forwardAmount * swingAmount;

        Quaternion yawRot = Quaternion.Euler(0f, mouseInput.x * rotateSpeed * Time.fixedDeltaTime, 0f);
        Quaternion pitchRot = Quaternion.Euler(swingAngle * Time.fixedDeltaTime, 0f, 0f);
        Quaternion targetRot = stilt.rotation * yawRot * pitchRot;

        stilt.MoveRotation(Quaternion.Slerp(stilt.rotation, targetRot, Time.fixedDeltaTime * rotationSmooth));
    }
}
