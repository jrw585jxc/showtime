using UnityEngine;

public class ForwardBackward : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;

    private Vector3 startPos;
    private bool goingForward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float direction = goingForward ? 1f : -1f;
        transform.Translate(Vector3.forward * direction * moveSpeed * Time.deltaTime);

        float distanceMoved = transform.position.z - startPos.z;

        if (goingForward && distanceMoved >= moveDistance)
            goingForward = false;
        else if (!goingForward && distanceMoved <= 0f)
            goingForward = true;
    }
}
