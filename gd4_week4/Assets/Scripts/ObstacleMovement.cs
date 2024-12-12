using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed = 10;
    public float xRange = -3.5f;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //_playerController = GameObject.FindFirstObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerController.isGameOver == false)
        {
            transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
        }
      

        if(transform.position.x < xRange)
        {
            Destroy(gameObject);
        }
    }
}
