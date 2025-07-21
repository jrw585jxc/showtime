using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{
    public int touchingFloorsCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        // If the other collider that collided with the trigger
        // has its layer set to "Floor"
        if (LayerMask.LayerToName(other.gameObject.layer) == "Floor")
        {
            // Increase the number of floors we're touching
            touchingFloorsCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the other collider that stopped colliding with the trigger
        // has its layer set to "Floor"
        if (LayerMask.LayerToName(other.gameObject.layer) == "Floor")
        {
            // Decrease the number of floors we're touching
            touchingFloorsCount--;
        }
    }

    // Create our own method for telling other scripts if we're touching the floor
    public bool IsTouchingFloor()
    {
        return touchingFloorsCount > 0;
    }
}
