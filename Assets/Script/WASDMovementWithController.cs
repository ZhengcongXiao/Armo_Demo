using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class WASDMovementWithController : MonoBehaviour {
    CharacterController controller;
    public float forwardSpeed = 5.0f;
    Vector3 moveVector;
    public float fallSpeed;
    public float jumpSpeed = 10.0f;
    public float tapSpeed = 0.5f;
    private float lastTapTime = 0.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        lastTapTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            
            moveVector = transform.TransformDirection(Vector3.forward);
            controller.Move(moveVector * forwardSpeed * Time.deltaTime);
            if ((Time.time - lastTapTime) < tapSpeed)
            {
                
            }
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(Vector3.back * 1 / 3 * forwardSpeed * Time.deltaTime);
            moveVector = transform.TransformDirection(Vector3.back);
            controller.Move(moveVector * forwardSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector = transform.TransformDirection(Vector3.left);
            controller.Move(moveVector * forwardSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector = transform.TransformDirection(Vector3.right);
            controller.Move(moveVector * forwardSpeed * Time.deltaTime);
        }

        //if (Input.GetButton("Jump"))
        //{
        //    fallSpeed = jumpSpeed;
        //
        //}

        if (!controller.isGrounded)
        {
            fallSpeed += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            if (Input.GetButton("Jump"))
            {
                fallSpeed = jumpSpeed;

            }
        }
        moveVector.y = fallSpeed;
        controller.Move(moveVector * Time.deltaTime);
    }
}
