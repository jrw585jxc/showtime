using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Set to root pelvis or empty GameObject near clown
    public Vector3 offset = new Vector3(0, 2, -5);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
