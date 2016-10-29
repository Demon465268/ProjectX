using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class P_Movement : MonoBehaviour
{
    private CharacterController controller;
    private Quaternion targetRotation;
    public float moveSpeed = 5.0f;
    public float rotationSmooth = 1.0f;

    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 horizontalDirection = Vector3.zero;
    private Vector3 verticalDirection = Vector3.zero;


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
            horizontalDirection = transform.TransformDirection(Vector3.left) * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            horizontalDirection = transform.TransformDirection(Vector3.right) * moveSpeed;
        }
        else
        {
            horizontalDirection = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {

            verticalDirection = Vector3.up * jumpSpeed;
        }

        verticalDirection.y -= gravity * Time.deltaTime;
        controller.Move((transform.TransformDirection(Vector3.forward) * moveSpeed + horizontalDirection) * Time.deltaTime);
	    controller.Move(verticalDirection * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * rotationSmooth * Time.deltaTime);
    }
}
