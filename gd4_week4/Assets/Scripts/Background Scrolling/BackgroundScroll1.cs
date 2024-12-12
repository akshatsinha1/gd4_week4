using UnityEngine;

public class BackgroundScroll1 : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] float scrollSpeed;
    float backgroundWidth;

    private PlayerController _playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        startPosition = transform.position;
        backgroundWidth = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.isGameOver == false)
        {
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
      

        if(transform.position.x < startPosition.x - (backgroundWidth/2))
        {
            transform.position = startPosition;
        }
    }
}
