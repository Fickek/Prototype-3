using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePref;
    private Vector3 obsatclePos = new Vector3(25, 0, 0);
    public float start = 2;
    public float spawnRepeat = 2;
    public PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", start, spawnRepeat);
    }

    
    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, 4);
            Instantiate(obstaclePref[obstacleIndex], obsatclePos, obstaclePref[obstacleIndex].transform.rotation);
        }     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
