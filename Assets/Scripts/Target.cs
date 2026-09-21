using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // Move the target in a straight direction from its origin point.
        // As all the walls have been oriented with Z axis facing the player playspace, we can use transform.forward
        transform.position += transform.forward * speed * Time.deltaTime;       // Time.deltaTime ensures the object moves at the same speed regardless of the frame rate
    }

    // Whenever an object with the Sword tag enters in contact with the target, the target is destroyed.
    private void OnTriggerEnter(Collider other)
    {
        // if the user hit the target with the sword:
        if (other.CompareTag("Sword"))
        {
            Destroy(gameObject);
            GameManager.Instance.UpdateScore(1);
        }
        // if the target touches the TransparentWall, it then disappear and get destroyed
        else if (other.CompareTag("TransparentWall"))
        {
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
    }
}
