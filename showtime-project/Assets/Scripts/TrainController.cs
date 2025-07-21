using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool shouldMove = false;

    public void StartMoving()
    {
        shouldMove = true;
    }

    void Update()
    {
        if (shouldMove)
        {
            transform.Translate(transform.right * moveSpeed * Time.deltaTime);
        }
    }
}
