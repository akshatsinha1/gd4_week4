using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5;
    Rigidbody rb;
    [SerializeField] private bool canJump;
    [SerializeField] float gravityModifier = 2;
    Animator anim;
    public bool isGameOver;

    public ParticleSystem dirtSplatter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //Physics.gravity = Physics.gravity * gravityModifier;
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump == true && isGameOver == false)
        {
            //jumping mechanic
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            canJump = false;
            anim.SetTrigger("Jump_trig");
            dirtSplatter.Stop();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Physics.gravity /= gravityModifier;

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        //whenever the player collides with any object, we set the bool to true
        canJump = true;
        Debug.Log(collision.transform.name);

        if(!isGameOver)dirtSplatter.Play();

        if(collision.transform.tag == "Obstacle")
        {
            //trigger a game over state
            isGameOver = true;
            //play a death animation
            anim.SetBool("Death_b", true);
            //stop everything else from moving
        }
    }

   
}
