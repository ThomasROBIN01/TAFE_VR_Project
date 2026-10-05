using JetBrains.Annotations;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;

    public GameObject bombPrefab1;
    public GameObject bombPrefab2;
    public GameObject bombPrefab3;
    public GameObject bombPrefab4;
    public GameObject bombPrefab5;
    public GameObject bombPrefab6;
    public GameObject bombPrefab7;
    public GameObject bombPrefab8;

    public GameObject shurikenPrefab1;
    public GameObject shurikenPrefab2;
    public GameObject shurikenPrefab3;
    public GameObject shurikenPrefab4;
    public GameObject shurikenPrefab5;
    public GameObject shurikenPrefab6;
    public GameObject shurikenPrefab7;
    public GameObject shurikenPrefab8;

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
        int randomSpawn = Random.Range(0, spawnWall.Length);

        // Attribute the matching wall
        Transform selectedSpawnWall = spawnWall[randomSpawn];

        // Select the target: if less that 20%: bomb, 10% chance of a shuriken (between 20 and 30%), otherwise arrow
        GameObject target;
        float targetProbability = Random.value;

        if (targetProbability < 0.2f)
        {
            // to have a bit of diversity, it'll choose between 8 different bombs assets:

            // Create an array of the 8 bombs to facilitate the random selection below
            GameObject[] bombrefabs =
            { bombPrefab1, bombPrefab2, bombPrefab3, bombPrefab4, bombPrefab5, bombPrefab6, bombPrefab7, bombPrefab8};

            // Select a random number among the 8 bombs from the array above
            int randomBomb = Random.Range(0, bombrefabs.Length);

            // Attribute the matching bomb
            GameObject selectedBomb = bombrefabs[randomBomb];

            target = selectedBomb;
        }
        else if (targetProbability >= 0.2f && targetProbability < 0.3f)
        {
            // to have a bit of diversity, it'll choose between 8 different shurikens assets:

            // Create an array of the 8 bombs to facilitate the random selection below
            GameObject[] shurikenPrefabs =
            { shurikenPrefab1, shurikenPrefab2, shurikenPrefab3, shurikenPrefab4, shurikenPrefab5, shurikenPrefab6, shurikenPrefab7, shurikenPrefab8};

            // Select a random number among the 8 shurikens from the array above
            int randomShuriken = Random.Range(0, shurikenPrefabs.Length);

            // Attribute the matching bomb
            GameObject selectedShuriken = shurikenPrefabs[randomShuriken];

            target = selectedShuriken;
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
