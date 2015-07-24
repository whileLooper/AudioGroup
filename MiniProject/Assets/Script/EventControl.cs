using UnityEngine;
using System.Collections;

public class EventControl : MonoBehaviour {

	Transform trans;
	bool isStandup = false;
	// Use this for initialization
	void Start () {
		trans = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			if (isStandup) {
				trans.localScale = new Vector3(1.0f, 1.8f, 1.0f);
				isStandup = !isStandup;
			}
			else {
				trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				isStandup = !isStandup;
			}
		}
	}

}
