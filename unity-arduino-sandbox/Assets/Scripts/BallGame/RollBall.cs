using UnityEngine;
using System.Collections;

public class RollBall : MonoBehaviour {

	public Rigidbody rb;
	public float thrust;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
		thrust = 5;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.DownArrow)) {

			rb.AddForce(-Vector3.forward * thrust);
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			rb.AddForce(Vector3.forward * thrust);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce(Vector3.left * thrust);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.AddForce(Vector3.right * thrust);
		}

	}
}
