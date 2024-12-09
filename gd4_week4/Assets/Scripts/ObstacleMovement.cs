using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed = 10;
    public float xRange = -3.5f;

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
