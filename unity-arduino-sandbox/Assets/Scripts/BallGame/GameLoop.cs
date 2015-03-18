using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour {

	public GameObject player;
	public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find("Monkey");
		spawnPoint = GameObject.Find("SpawnPoint");

	}
	
	// Update is called once per frame
	void Update () {
	
		if (player.transform.position.y <= -30) {

			// reset player
			player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			player.transform.position = spawnPoint.transform.position;

		}

	}
}
