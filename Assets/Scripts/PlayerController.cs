using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtRun;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 10.0f;
    public float gravityModifier;

    public bool onTheGround = true;
    public bool gameOver = false;
    private bool doubleJump = true;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onTheGround && !gameOver && doubleJump)
        {     
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            playerAnim.SetTrigger("Jump_trig");
            dirtRun.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            onTheGround = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doubleJump = false;
            onTheGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onTheGround = true;
            doubleJump = true;
            dirtRun.Play();
        } 
        else if(collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtRun.Stop();
            playerAudio.PlayOneShot(crashSound, 2.0f);
        }
    }

}
