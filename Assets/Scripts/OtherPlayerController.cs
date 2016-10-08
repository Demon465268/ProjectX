using UnityEngine;
using System.Collections;

public class OtherPlayerController : MonoBehaviour
{
    
    private CharacterController controller;
    public Vector3 moveVector;
    // Use this for initialization
    public float maxSpeed;
    public float verticalVelocity;
    private const float gravity = 12.0f;
    public string scale = "Forward";
    void Start () {
        controller = GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        float turnToTheSide = Input.GetAxis("Horizontal");
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
            moveVector.z = maxSpeed;
           
       
        controller.Move(moveVector * Time.deltaTime);

        
    
    }
 
}
