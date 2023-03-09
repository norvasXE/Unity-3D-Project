using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float moveSpeed = 2;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("w")) 
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey("s"))
        {
            transform.position += -transform.forward * Time.deltaTime * moveSpeed;
        }
        if(Input.GetKey("a"))
        {
            //transform.position += transform.forward.Normalize(new Vector3(1, 0, 0)) * Time.deltaTime * moveSpeed;
        }

    }
}
