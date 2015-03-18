using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class RollBallAdv : MonoBehaviour {
	
	SerialPort serial = new SerialPort("/dev/tty.usbmodem1421", 9600);
	public GameObject rollObject;
	public Rigidbody rb;
	public float threshold;
	public string dir;
	public float thrust;

	// Use this for initialization
	void Start () {
		serial.Open ();
		serial.ReadTimeout = 1;
		
		rollObject = GameObject.Find ("Monkey");	
		rb = GetComponent<Rigidbody>();
		threshold = 50;
		dir = "none";
		thrust = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
		// read one serial value from arduino
		if (serial.IsOpen) {
			
			try {
				
				string readValue = serial.ReadLine ();
				
				// roll ball based on accel angles
				string[] values = readValue.Split(',');
				//print ("x : " + values[0] + " y: " + values[1] + " z: " + values[2]); // + " z: " + values[2]);

				float xM = float.Parse (values[0]);
				float yM = float.Parse (values[1]);

				if ( xM > threshold) {
					rb.AddForce(Vector3.left * thrust);
				} else if ( xM < -threshold) {
					rb.AddForce(Vector3.right * thrust);
				}

				if ( yM > threshold) {
					rb.AddForce(-Vector3.forward * thrust);

				} else if ( yM < -threshold) {
					rb.AddForce(Vector3.forward * thrust);
				}

				//float xMap = map(float.Parse (values[0]), 270.0f, -270.0f, -90.0f, 90.0f);
				//float yMap = map(float.Parse (values[1]), 270.0f, -270.0f, -90.0f, 90.0f);
				//float zMap = map(float.Parse (values[2]), 270.0f, -270.0f, -90.0f, 90.0f);

				
			} catch {
				
				// catch error
				
			}
			
			
		}	
	}
	
	public float map(float s, float a1, float a2, float b1, float b2) {
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}
	
}
