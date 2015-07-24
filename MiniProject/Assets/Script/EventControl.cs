using UnityEngine;
using System.Collections;

public class EventControl : MonoBehaviour {

	Transform trans;
	Shader shad;
	Renderer rend;
	bool isStandup = false;

	// Use this for initialization
	void Start () {
		trans = gameObject.GetComponent<Transform> ();
		shad = gameObject.GetComponent<Shader> ();
		rend = gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("3")) {
			if (isStandup) {
				trans.localScale = new Vector3(1.0f, 1.8f, 1.0f);
				rend.material.SetColor("Albedo", Color.red);
				isStandup = !isStandup;
			}
			else {
				trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				isStandup = !isStandup;
			}
		}
	}

}
