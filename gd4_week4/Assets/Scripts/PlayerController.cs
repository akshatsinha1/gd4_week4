using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5;
    Rigidbody rb;
    [SerializeField] private bool canJump;
    [SerializeField] float gravityModifier = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Physics.gravity = Physics.gravity  gravityModifier;
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            //jumping mechanic
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            canJump = false;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Physics.gravity /= gravityModifier;
            SceneManager.LoadScene(0);
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        //whenever the player collides with any object, we set the bool to true
        canJump = true;
        Debug.Log(collision.transform.name);
    }
}
