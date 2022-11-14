using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    public float floatForce;
    private float gravityModifier = 1f;
    private Rigidbody playerRb;

    public float borderUp = 12;
    public float borderDown = 4.5f;
    private bool isLowEnough = true;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        //playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < borderUp)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }


        /*if(transform.position.y > borderUp)
        {
            transform.position = new Vector3(transform.position.x, borderUp, 0);
        }
        if (transform.position.y < borderDown)
        {
            playerRb.AddForce(Vector3.up, ForceMode.Impulse);
            
            //transform.position = new Vector3(transform.position.x, borderDown, 0);
        }*/

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {    
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            //Destroy(gameObject);
            Destroy(other.gameObject);
            explosionParticle.Play();
        } 
        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

}
