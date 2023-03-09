using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMechanics : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [Header("Data")]
    [SerializeField] public Data data = default;

    [Header("Sounds")]
    PlayerAudioController playerAudioController;

    [Header("Movement")]
    [SerializeField] private float speed;

    [SerializeField] private Vector3 moveDirection = default;

    [SerializeField] private float horizontalMovement = default;
    [SerializeField] private float verticalMovement = default;
    [SerializeField] private float movementMultiplier = 10f;
    [SerializeField] private float airMultiplier = 0.4f;

    [SerializeField] private Rigidbody rb = default;

    [Header("Drag")]
    [SerializeField] private float groundDrag = 6f;
    [SerializeField] private float airDrag = 0.01f;

    [Header("Rotation")]
    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;

    [SerializeField] Transform cameraPoint = default;
    [SerializeField] Camera cam = default;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    [Header("Jump")]
    [SerializeField] private float jumpForce = default;
    [SerializeField] private bool isGrounded = default;

    void Start()
    {
        
        playerAudioController = GetComponent<PlayerAudioController>();
        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

   
    void Update()
    {
        // if we can move
        if (data.canMove)
        {
            //Function call
            ConrolDrag();

            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");

            //Create a local variable and ignoring the force on the y-axis assign the magnitude of this vector
            float speedForAnimation = new Vector3(rb.velocity.x, 0f ,rb.velocity.z).magnitude;
            //Assign speed variable in animation to magnitude value
            animator.SetFloat("Speed", speedForAnimation);

            //If the magnitude of the force is greater than 0.2
            if (rb.velocity.magnitude > 0.2f)
            {
                //If coroutine is not running
                if (playerAudioController.footStepCoroutine == null)
                {
                    //Run it on playerAudioController script
                    playerAudioController.footStepCoroutine = playerAudioController.StartCoroutine(playerAudioController.PlayFootSteps());
                }
            }
            else
            {
                //If the coroutine is running
                if (playerAudioController.footStepCoroutine != null)
                {
                    //stop it
                    playerAudioController.StopCoroutine(playerAudioController.footStepCoroutine);
                    //And set the variableplayerAudioController.footStepCoroutine to zero
                    playerAudioController.footStepCoroutine = null;
                }
            }
            //Assign to variable moveDirection - vector of movement direction
            moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
            //Function call
            Look();

            //If you press the Space and if we are on ground
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                //Give impulse direction along the y axis
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                // start animation (Jump)
                animator.SetTrigger("Jump");
            }
            //If you press the left shift
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //Increase speed - twice
                speed *= 2f;
            }

            //If you release the left shift
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //Decrease speed - twice
                speed /= 2f;
            }
        }
    }

    private void ConrolDrag()
    {
        //If we are on ground
        if (isGrounded)
        {
            //Changes in air resistance
            rb.drag = groundDrag;
            //Reset trigger for animation (Jump)
            animator.ResetTrigger("Jump");
        }
        else
        {
            //Changes in air resistance
            rb.drag = airDrag;
        }
    }

    private void Look()
    {
        //The camera position is equal to the position of the character's eye.
        cam.transform.position = cameraPoint.position;

        //Assign the variable mouseX and mouseY to the position of the mouse.
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        //Increase the value of the y Rotation variable.
        yRotation += mouseX * sensX * multiplier;
        //Decrease the value of the y Rotation variable.
        xRotation -= mouseY * sensY * multiplier;

        //Limit Camera Rotation to X-Axis
        xRotation = Mathf.Clamp(xRotation, -60f, 90f);
        //change the position of the camera relative to local coordinates by a given angle.
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Change the rotation of the character relative to world coordinates along the Y axis to the given angle.
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    private void FixedUpdate()
    {
        // if we can move
        if (data.canMove)
        {
            // get start position for check ground 
            Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            //Launch a beam and if we hit the collider, then we are on the ground (true) otherwise (false)
            isGrounded = Physics.Raycast(startPosition, transform.TransformDirection(Vector3.down), 0.2f);
            // if we are on ground
            if (isGrounded)
            {
                //Give strength to the character in the direction where we are moving (no air resistance)
                rb.AddForce(moveDirection.normalized * speed * movementMultiplier, ForceMode.Acceleration);
            }
            else //if we are in the air
            {
                //Give strength to the character in the direction where we are moving (with air resistance)
                rb.AddForce(moveDirection.normalized * speed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
            }
        }
    }
}
