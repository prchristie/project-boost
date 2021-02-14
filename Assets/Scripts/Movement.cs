using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField]
    float thrustForce = 1000f;

    [SerializeField]
    float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if(Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void ProcessThrust() {
        if(Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }    
    }
}
