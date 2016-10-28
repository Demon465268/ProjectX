using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    public float moveSpeed;
    public float verticalVelocity;
    public float rotationSmooth = 1.0f;

    void Start()
    {
        targetRotation = GetComponent<Rigidbody>().transform.rotation;
        targetPosition = GetComponent<Rigidbody>().transform.position;
    }


    void Update()
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
            targetPosition = Vector3.forward + Vector3.left;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            targetPosition = Vector3.forward + Vector3.right;
        }
        else
        {
            targetPosition = Vector3.forward;
        }

        transform.Translate(targetPosition * moveSpeed * Time.deltaTime, Space.Self);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * rotationSmooth * Time.deltaTime);
    }
}