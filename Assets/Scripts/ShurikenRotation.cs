using UnityEngine;

public class ShurikenRotation : MonoBehaviour
{
    public float rotationSpeed = 720f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        // Rotate the target on the Y axis:
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);       // Time.deltaTime ensures the object moves at the same speed regardless of the frame rate
    }
}
