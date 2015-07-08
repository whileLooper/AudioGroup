using UnityEngine;
using System.Collections;

public class BusController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) {
			print ("Pressed A");
			transform.Rotate(Vector3.down, Space.World);
		}

		if (Input.GetKey(KeyCode.D)) {
			print ("Pressed D");
			transform.Rotate (Vector3.up, Space.World);
		}
	}
}
