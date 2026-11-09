using UnityEngine;

public class SwordHitDetector : MonoBehaviour
{
    private Vector3 previousPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the initial position of the sword
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the sword
        Vector3 currentPosition = transform.position;

        Vector3 movementDirection = currentPosition - previousPosition;
        Vector3 directionNormalised = movementDirection.normalized; // a normalised vector (magnitude of 1) is expected for Physics.SphereCast() later.

        // Distance between the 2 vectors is calculated with the Euclidean distance:
        //float distance = Mathf.Sqrt (movementDirection.x * movementDirection.x 
        //                            + movementDirection.y * movementDirection.y
        //                            + movementDirection.z * movementDirection.z);
        // or:
        // float distance = Vector3.Distance(previousPosition, currentPosition);
        float distance = movementDirection.magnitude;   // calculate the vector length / Euclidean distance as above



        // update the previousPosition ot the current one for the next frame:
        previousPosition = currentPosition;
    }
}
