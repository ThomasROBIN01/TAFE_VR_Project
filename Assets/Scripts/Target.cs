using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;       // Time.deltaTime ensures the object moves at the same speed regardless of the frame rate
    }

    // Whenever an object with the Paddle tag enters in contact with the target, the target is destroyed.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            Destroy(gameObject);
        }
    }
}
