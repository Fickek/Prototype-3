using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBg : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth; 

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //Debug.LogFormat("Start Position BG: {0}", startPos);
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        //Debug.Log(repeatWidth); 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
            //Debug.Log(transform.position);
        }
        
    }
}
