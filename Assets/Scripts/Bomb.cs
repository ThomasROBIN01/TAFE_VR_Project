using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 1f;

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
            Debug.Log("Pay attention, this was a bomb!");
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
        else if (other.CompareTag("TransparentWall"))
        {
            Destroy(gameObject);
        }
    }
}
