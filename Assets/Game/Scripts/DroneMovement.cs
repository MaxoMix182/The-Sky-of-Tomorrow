using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DroneMovement : MonoBehaviour
{
    public Transform orientation; 

    public float AirDrag;
    public float FlightSpeed;
    public float Boostmultiplier;
    float Boost = 1f;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;



    public float angle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * FlightSpeed * Time.deltaTime * Boost, ForceMode.Force);

        if (Input.GetKey(KeyCode.Mouse0))
            {

            Vector3 Up = new Vector3(0, 1, 0);
            
                rb.AddForce(Up.normalized * FlightSpeed * Time.deltaTime, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {

            Vector3 Down = new Vector3(0, -1, 0);

            rb.AddForce(Down.normalized * FlightSpeed * Time.deltaTime, ForceMode.Force);
        }



        rb.drag = AirDrag;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Boost = Boostmultiplier;
        }
        else
        {
            Boost = 1f;
        }
            
        

    }

    private void FixedUpdate()
    {
       
    }

    private void MyInput()
    {
      
    }

    private void MoveDrone()
    {
        
    }
}