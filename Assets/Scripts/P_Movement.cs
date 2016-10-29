using UnityEngine;
using System.Collections;

public class P_Movement : MonoBehaviour {

    private Quaternion targetRotation;
    private Vector3 targetPosition;
    public float moveSpeed;
    public float rotationSmooth = 1.0f;

    void Start ()
    {
        targetRotation = GetComponent<Rigidbody>().transform.rotation;
        targetPosition = GetComponent<Rigidbody>().transform.position;
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
            targetPosition = Vector3.forward + Vector3.left;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            targetPosition = Vector3.forward + Vector3.right;
        }
        else
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetPosition = Vector3.forward + Vector3.up * 50;
        }
        else
        {
            targetPosition = Vector3.forward;
        }

        transform.Translate(targetPosition * moveSpeed * Time.deltaTime, Space.Self);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * rotationSmooth * Time.deltaTime);
    }
}
