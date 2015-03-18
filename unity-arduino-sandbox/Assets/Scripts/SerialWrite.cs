using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class SerialWrite : MonoBehaviour {

	// replace the serial port with your own
	SerialPort serial = new SerialPort("/dev/tty.usbmodem1421", 9600);
	bool isOn;

	// Use this for initialization
	void Start () {

		// initialize to off
		isOn = false;

	}
	
	// Update is called once per frame
	void Update () {

		if(!serial.IsOpen) {
			serial.Open ();
			serial.Write ("0"); // off
		}

	}

	void OnMouseDown() {

		// toggle the light
		isOn = !isOn;

		if (isOn)
			serial.Write ("1");
		else
			serial.Write ("0");

	}

}
