using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null ;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private int superJumpsRemaining;
   
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        
    }
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
        
        if (Physics.OverlapSphere(groundCheckTransform.position,0.1f,playerMask).Length==0)
        { 
            return;
        }
        if (jumpKeyWasPressed)
        {
            float jumpPower = 5;
            if(superJumpsRemaining>5)
            {
                jumpPower += 2;
                superJumpsRemaining--;
            }
            
            GetComponent<Rigidbody>().AddForce(Vector3.up*jumpPower,ForceMode.VelocityChange);
            jumpKeyWasPressed=false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==7 )
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
        if (other.gameObject.layer == 8)
        {
            Destroy(other.gameObject);
            Debug.Log("Power up");
        }
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            Debug.Log("Power down");
        }
        if (other.gameObject.layer == 10)
        {
            Destroy(other.gameObject);
            Debug.Log("YOU ARE DEAD!!");
        }
    }

}
