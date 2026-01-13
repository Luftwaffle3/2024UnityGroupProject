using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float minY;
    public float minXLimit = -10f; // the minimum x position limit

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Clamp the Y position to prevent it from going below minY
        smoothedPosition.y = Mathf.Max(smoothedPosition.y, minY);

        // Clamp the X position to prevent it from going beyond -10
        smoothedPosition.x = Mathf.Max(smoothedPosition.x, minXLimit);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}