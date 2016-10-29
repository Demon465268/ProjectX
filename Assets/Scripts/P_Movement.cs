using UnityEngine;
using System.Collections;

public class P_Movement : MonoBehaviour
{
    private CharacterController controller;
    private Quaternion targetRotation;
    public float moveSpeed = 5.0f;
    public float rotationSmooth = 1.0f;

    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Start ()
    {
        targetRotation = GetComponent<Rigidbody>().transform.rotation;
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
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
            moveDirection = transform.TransformDirection(Vector3.left) * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveDirection = transform.TransformDirection(Vector3.right) * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            
            moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move((transform.TransformDirection(Vector3.forward) * moveSpeed) + moveDirection * Time.deltaTime);
        //controller.Move(transform.TransformDirection(Vector3.forward) * moveSpeed * Time.deltaTime);

        //transform.Translate(targetPosition * moveSpeed * Time.deltaTime, Space.Self);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * rotationSmooth * Time.deltaTime);
    }
}
