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

    AudioSource _audioSource;
    public AudioClip jumpSound, crashSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
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

            _audioSource.PlayOneShot(jumpSound);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Physics.gravity /= gravityModifier;

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
   public void animationEventTest()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //whenever the player collides with any object, we set the bool to true
        canJump = true;
        Debug.Log(collision.transform.name);

        dirtSplatter.Play();

        if(collision.transform.tag == "Obstacle")
        {
            //trigger a game over state
            isGameOver = true;
            //play a death animation
            anim.SetBool("Death_b", true);
            //stop everything else from moving
            _audioSource.PlayOneShot(crashSound);
            

        }
    }

   
}
