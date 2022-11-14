using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerContollerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerContollerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Dash");
            speed *= 2;
            playerContollerScript.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        } 
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 30;
            
        }

    }
}
