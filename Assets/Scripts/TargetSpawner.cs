using JetBrains.Annotations;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject bombPrefab;

    public Transform frontWall;
    public Transform leftWall;
    public Transform rightWall;

    public float spawnInterval = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), 0f, spawnInterval);    // 0 seconds after starting, call the SpawnTarget method below, and repeat it every "spawnInterval".
    }

    // Select a random wall among the 3, and then create a random position on Y and Z, to create the target at that position
    public void SpawnTarget()
    {
        // Create an array of the 3 walls to facilitate the random selection below
        Transform[] spawnWall =
        {
            frontWall, rightWall, leftWall
        };

        // Select a random number among the 3 walls from the array above
        //int randomSpawn = Random.Range(0, spawnWall.Length);
        int randomSpawn = Random.Range(0, spawnWall.Length);

        // Attribute the matching wall
        Transform selectedSpawnWall = spawnWall[randomSpawn];

        // Select the target: if less that 20%: bomb, otherwise arrow
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

        // Create a random position on Y and X
        // Vector3 randomOffset = new Vector3(transform.position.x, Random.Range (1f, 1.5f), Random.Range(-1f, 1f));   // transform.position.x: create the vector at the position of the object on X)
        Vector3 randomOffset = selectedSpawnWall.up * Random.Range(1f, 1.5f) + selectedSpawnWall.right * Random.Range(-1f, 1f);

        // Take the initial position of the selected wall, add the randomOffset to it, and then spawn the target there.
        Vector3 spawnPositionOnWall = randomOffset + selectedSpawnWall.position;

        // Create the target at that position:
        // Instantiate(targetPrefab, randomPosition, Quaternion.identity);     // Quaternion.identity uses the defualt rotation (0,0,0) which makes the target appearing wrongly, instead: 
        Instantiate(target, spawnPositionOnWall, selectedSpawnWall.rotation);        // Instantiate(WHAT, WHERE, ROTATION)

    }
}
