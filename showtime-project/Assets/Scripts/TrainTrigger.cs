using UnityEngine;

public class TrainTriggerAndFriction : MonoBehaviour
{
    private bool trainStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Parent player for "friction"
            other.transform.SetParent(transform);

            // Start train only once
            if (!trainStarted)
            {
                GetComponentInParent<TrainController>()?.StartMoving();
                trainStarted = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Unparent player when they leave the train
            other.transform.SetParent(null);
        }
    }
}
