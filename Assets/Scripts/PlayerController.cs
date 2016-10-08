using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 moveVector;
    // Use this for initialization
    public float maxSpeed;
    public float verticalVelocity;
    private const float gravity = 12.0f;
    public float speed = 0.01f;
    // Use this for initialization
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, speed);
        GetComponent<Rigidbody>().transform.Translate(Vector3.forward * speed, Space.Self);
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, speed);
        GetComponent<Rigidbody>().transform.Translate(new Vector3(0.0f, 0.0f, 0.1f)/*Vector3.forward*speed*/, Space.Self);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //GetComponent<Rigidbody>().transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            //GetComponent<Rigidbody>().transform.rotation = Quaternion.AngleAxis(-90, Vector3.down); 
            //GetComponent<Rigidbody>().transform.Translate();
            GetComponent<Rigidbody>().transform.Rotate(Vector3.up * 90, Space.Self);
            GetComponent<Rigidbody>().transform.Translate(new Vector3(0.1f, 0.0f, 0.0f), Space.Self);
            //GetComponent<Rigidbody>().velocity = new Vector3(speed, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //GetComponent<Rigidbody>().transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
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
    void Update()
    {
       



    }
}
 

