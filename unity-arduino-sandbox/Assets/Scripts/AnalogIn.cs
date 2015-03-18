using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class AnalogIn : MonoBehaviour {

	SerialPort serial = new SerialPort("/dev/tty.usbmodem1421", 9600);
	public GameObject lightSource;

	// Use this for initialization
	void Start () {
		serial.Open ();
		serial.ReadTimeout = 1;
		
		lightSource = GameObject.Find ("Light");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (serial.IsOpen) {
			
			try {
				// read one serial value from arduino
				float readVal = float.Parse (serial.ReadLine ());
				lightSource.GetComponent<Light>().intensity = readVal;

				print ("light value: " + readVal);
				
			} catch {
				// catch error
				
			}
			
			
		}
	}
}
