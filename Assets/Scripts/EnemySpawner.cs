using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;


    [SerializeField]
    [Range(0,5)]
    float spawnHalfExtent, spawnInterval = 0.75f, spawnTimeMultiplierMin, spawnTimeMultiplierMax;

    [SerializeField]
    [Range(1,10)]
    private int scoreModulus;

    [Space]
    [HideInInspector]
    public int score;


    float nextSpawn, spawnTimeMultiplier;
    int spawnID;

    void Update()
    {
        if (nextSpawn <= Time.time)
        {
            spawnID = Random.Range(0, enemies.Length);
            spawnTimeMultiplier = Random.Range(spawnTimeMultiplierMin, spawnTimeMultiplierMax);
            spawnHalfExtent = Random.Range(-4.4f, 4.4f);

            Instantiate(enemies[spawnID], new Vector3(transform.position.x, spawnHalfExtent, 0), Quaternion.identity);
            nextSpawn = (Time.time + spawnInterval * spawnTimeMultiplier) - (score % 3);
        }
    }
}
