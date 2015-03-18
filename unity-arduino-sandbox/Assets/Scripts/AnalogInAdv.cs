using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class AnalogInAdv : MonoBehaviour {

	SerialPort serial = new SerialPort("/dev/tty.usbmodem1421", 9600);
	public GameObject rotationObject;

	// Use this for initialization
	void Start () {
		serial.Open ();
		serial.ReadTimeout = 1;
		
		rotationObject = GameObject.Find ("Switch");	
	}
	
	// Update is called once per frame
	void Update () {

		// read one serial value from arduino
		if (serial.IsOpen) {
			
			try {
				
				string readValue = serial.ReadLine ();
				
				// method 1
				//float mapX = map(float.Parse (readValue), -270.0f, 270.0f, -90.0f, 90.0f);
				//rotationObject.transform.localEulerAngles = new Vector3(0, 0, mapX);
				
				
				// method 2
				string[] values = readValue.Split(',');
				print ("x : " + values[0] + " y: " + values[1] + " z: " + values[2]); // + " z: " + values[2]);
				float xMap = map(float.Parse (values[0]), 270.0f, -270.0f, -90.0f, 90.0f);
				float yMap = map(float.Parse (values[1]), 270.0f, -270.0f, -90.0f, 90.0f);
				float zMap = map(float.Parse (values[2]), 270.0f, -270.0f, -90.0f, 90.0f);
				rotationObject.transform.localEulerAngles = new Vector3(xMap, yMap, zMap);
				
				
			} catch {
				
				// catch error
				
			}
			
			
		}	
	}

	public float map(float s, float a1, float a2, float b1, float b2) {
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}

}
