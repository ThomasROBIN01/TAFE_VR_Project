using JetBrains.Annotations;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject bombPrefab;
    public float spawnInterval = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), 0f, spawnInterval);    // 0 seconds after starting, call the SpawnTarget method below, and repeat it every "spawnInterval".
    }

    // Create a random position on Y and Z, and create the target at that position
    public void SpawnTarget()
    {
        // 1. Select the target: if less that 20%: bomb, otherwise arrow
        GameObject target;
        float targetProbability = Random.value;

        if (targetProbability < 0.2f)
        {
            target = bombPrefab;
        }
        else
        {
            target = arrowPrefab;
        }

        // Create a random position on Y and Z
        Vector3 randomPosition = new Vector3(transform.position.x, Random.Range (1f, 1.5f), Random.Range(-1f, 1f));   // transform.position.x: create the vector at the position of the object on X)

        // Create the target at that position:
        // Instantiate(targetPrefab, randomPosition, Quaternion.identity);     // Quaternion.identity uses the defualt rotation (0,0,0) which makes the target appearing wrongly, instead: 
        Instantiate(target, randomPosition, target.transform.rotation);     // targetPrefab.transform.rotation: uses the default targetPrefab rotation (as saved in the Editor)

    }
}
