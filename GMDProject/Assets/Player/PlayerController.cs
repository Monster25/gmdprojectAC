using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    private CameraController playerCamera;
    private float forwardBackwardValue, leftRightValue, lookUpDownValue, lookLeftRightValue;
    private bool grabValue;
    private Vector3 forwardVelocity, rightVelocity, eulerAngleVelocity, movementVelocity;
    private Rigidbody playerRb;
    private CapsuleCollider playerCollider;
    private Grabber grabber;
    [SerializeField]
    private float movementSpeed = 0;
    private float rotationSpeed = 0;
    [SerializeField]
    private float jumpHeight = 0;
    private float rotX;
    private bool isGrounded;
    private bool jumpValue;

    void Awake()
    {
        //Initial Refs
        playerTransform = gameObject.GetComponent<Transform>();
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        playerCamera = playerTransform.GetChild(0).GetComponent<CameraController>();
        rotationSpeed = playerCamera.GetLookSpeed();
        
        //Disable cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Read and store input
        //Movement
        forwardBackwardValue = Input.GetAxisRaw("ForwardBackward");
        leftRightValue = Input.GetAxisRaw("LeftRight");
        //Rotation
        lookLeftRightValue = Input.GetAxis("Mouse X");
        //Jump
        jumpValue = Input.GetButtonDown("Jump");
       
       
        //Calcualte Player Rotation;
        rotX +=lookLeftRightValue*rotationSpeed;

        //Rotate player
        playerTransform.rotation = Quaternion.Euler(0f, rotX, 0f);

        //Jump
        if (jumpValue == true && IsGrounded())
        {
            //Add impulse instead of force because force is added over frames.
            playerRb.AddForce(playerTransform.up*jumpHeight, ForceMode.Impulse);
        }

    }

    void FixedUpdate()
    {
        //Calculate movement velocity
        forwardVelocity = playerTransform.forward * forwardBackwardValue * movementSpeed * Time.deltaTime;
        rightVelocity = playerTransform.right * leftRightValue * movementSpeed * Time.deltaTime;
        movementVelocity = forwardVelocity+rightVelocity;
        //Fix Diagonal Movement
        if (forwardVelocity.magnitude>0 && rightVelocity.magnitude>0)
        movementVelocity = movementVelocity/(float)Math.Sqrt(2);

        //Move player
        playerRb.MovePosition(playerTransform.position + movementVelocity);

    }

    void LateUpdate()
    {

    }

    bool IsGrounded()
    {
        float distanceToTheGround = playerCollider.bounds.extents.y;
        RaycastHit hitInfo;
        return Physics.SphereCast(playerTransform.position, playerCollider.radius, Vector3.down, out hitInfo, distanceToTheGround);
    }
}
