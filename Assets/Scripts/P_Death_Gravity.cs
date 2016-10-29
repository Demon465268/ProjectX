using UnityEngine;
using System.Collections;

public class P_Death_Gravity : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveVector;
    public float jumpHeight = 1.0f;
    public bool isDead = false;
    public float verticalVelocity = 0.0f;
    public float gravity = 12.0f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Падение
        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;

        }
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);

        //// Смерть
        //if (verticalVelocity < -30f)
        //{
        //    isDead = true;
        //}
        //if (isDead)
        //{
        //    transform.position = new Vector3(0.0f, 1.5f, 0.0f);
        //    verticalVelocity = -0.5f;
        //    isDead = false;
        //    //return;
        //}
    }
}
