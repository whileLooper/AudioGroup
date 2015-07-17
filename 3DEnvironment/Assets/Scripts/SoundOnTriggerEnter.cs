using UnityEngine;
using System.Collections;

public class SoundOnTriggerEnter : MonoBehaviour {

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		CharacterController controller = other.gameObject.GetComponent<CharacterController> ();
		if (controller != null) { //meaning we have the character
			if (audioSource.isPlaying == false)
				audioSource.Play ();
		}

	}
	
}
