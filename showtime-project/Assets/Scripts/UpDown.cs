using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float moveDistance = 2f;    
    public float moveSpeed = 2f;       

    private Vector3 startPos;
    private bool goingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = goingUp ? 1f : -1f;
        transform.Translate(Vector3.up * direction * moveSpeed * Time.deltaTime);

        float distanceMoved = transform.position.y - startPos.y;

        if (goingUp && distanceMoved >= moveDistance)
            goingUp = false;
        else if (!goingUp && distanceMoved <= 0f)
            goingUp = true;
    }
}
