using UnityEngine;
using System.Collections;

public class EventControl : MonoBehaviour {

	Transform trans;
	Shader shad;
	Renderer rend;
	bool isStandup = false;
	AudioSource source;

	// Use this for initialization
	void Start () {
		trans = gameObject.GetComponent<Transform> ();
		shad = gameObject.GetComponent<Shader> ();
		rend = gameObject.GetComponent<Renderer> ();
		source = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("3")) {
			if (isStandup) {
				trans.localScale = new Vector3(1.0f, 1.8f, 1.0f);
				rend.material.SetColor("Albedo", Color.red);
				isStandup = !isStandup;
				if (!source.isPlaying) {
					source.Play();
				}
			}
			else {
				trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				isStandup = !isStandup;
				source.Stop();
			}
		}
	}

}
