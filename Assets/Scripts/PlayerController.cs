using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 moveVector;
    public float maxSpeed;
    public float verticalVelocity;
    private const float gravity = 12.0f;
    public float speed = 0.01f;


    void Start()
    {
        GetComponent<Rigidbody>().transform.Translate(Vector3.forward * speed, Space.Self);
        controller = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody>().transform.Translate(new Vector3(0.0f, 0.0f, 0.1f)/*Vector3.forward*speed*/, Space.Self);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().transform.Rotate(Vector3.up * 90, Space.Self);
            GetComponent<Rigidbody>().transform.Translate(new Vector3(0.1f, 0.0f, 0.0f), Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().transform.Rotate(Vector3.up * -90, Space.Self);
            GetComponent<Rigidbody>().transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f), Space.Self);

        }

        moveVector = Vector3.zero;
           if (controller.isGrounded)
           {
               verticalVelocity = -0.5f;
           }
           else
           {
               verticalVelocity -= gravity * Time.deltaTime;
           }
        //X - Left and Right
        moveVector.x = Input.GetAxisRaw("Submit") * maxSpeed;
        //Y - Up and Down
        moveVector.y = verticalVelocity;
        //Z - Forward and Backward
        // moveVector.z = maxSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }
}
 

