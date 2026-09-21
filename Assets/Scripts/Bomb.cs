using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        // Move the "bomb" in a straight direction from its origin point.
        // As all the walls have been oriented with Z axis facing the player playspace, we can use transform.forward
        transform.position += transform.forward * speed * Time.deltaTime;       // Time.deltaTime ensures the object moves at the same speed regardless of the frame rate
    }

    // Whenever an object with the Paddle tag enters in contact with the target, the target is destroyed.
    private void OnTriggerEnter(Collider other)
    {
        // if the user hit the bomb with the sword:
        if (other.CompareTag("Sword"))
        {
            Debug.Log("Pay attention, this was a bomb!");
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
        // if the bomb touches the TransparentWall, it then disappear and get destroyed
        else if (other.CompareTag("TransparentWall"))
        {
            Destroy(gameObject);
        }
    }
}
