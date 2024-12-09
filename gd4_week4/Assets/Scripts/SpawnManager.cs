using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Vector3 spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnObstacles", 2, 3);
    }

    void spawnObstacles()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, Quaternion.identity);
    }
}
