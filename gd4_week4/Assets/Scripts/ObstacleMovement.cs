using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed = 10;
    public float xRange = -3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);

        if(transform.position.x < xRange)
        {
            Destroy(gameObject);
        }
    }
}
