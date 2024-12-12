using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Vector3 spawnPosition;
    private PlayerController _playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //_playerController = GameObject.FindFirstObjectByType<PlayerController>();
        InvokeRepeating("spawnObstacles", 2, 3);
    }
    private void Update()
    {
        if (_playerController.isGameOver == true) CancelInvoke("spawnObstacles");
    }
    void spawnObstacles()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, Quaternion.identity);
    }
}
