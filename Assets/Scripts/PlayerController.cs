using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    private Rigidbody rigidbody;
    private Vector3 moveVector;
    public float moveSpeed;
    public float rotationSmooth = 1.0f;
    public float jumpHeight = 1.0f;
    public bool isDead = false;
    public bool isFalling = false;
    public float verticalVelocity = 0.0f;
    public float gravity = 12.0f;
    void Start()
    {
        targetRotation = GetComponent<Rigidbody>().transform.rotation;
        targetPosition = GetComponent<Rigidbody>().transform.position;
        rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (verticalVelocity < -5.6f)
        {
            isDead = true;
        }
        if (isDead)
        {
            transform.position = new Vector3(0.0f, 1.5f, 0.0f);
            return;
        }
        moveVector = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            targetPosition = Vector3.forward + Vector3.left;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            targetPosition = Vector3.forward + Vector3.right;
        }
        else
        if (Input.GetKeyDown(KeyCode.W))
        {
          
        }
        else
        {
            targetPosition = Vector3.forward;
        }
        
         
        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity*Time.deltaTime;

        }
        moveVector.y = verticalVelocity;
        transform.Translate(targetPosition * moveSpeed * Time.deltaTime, Space.Self);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * rotationSmooth * Time.deltaTime);
        controller.Move(moveVector * Time.deltaTime);
    }
}