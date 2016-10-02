using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour
{

    public float speed = 0.01f;
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, speed);
        GetComponent<Rigidbody>().transform.Translate(Vector3.forward * speed, Space.Self);
	}

	
	// Update is called once per frame
	void FixedUpdate () {
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
        

    }
}
