using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            rb.AddForce(new Vector3(rb.velocity.x,rb.velocity.y + 1, rb.velocity.z));
        }
        else if (Input.GetKeyDown("s"))
        {
            rb.AddForce(new Vector3(0, 0, 0));
        }
    }
}
