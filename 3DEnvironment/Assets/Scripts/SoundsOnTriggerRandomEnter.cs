using UnityEngine;
using System.Collections;

public class SoundsOnTriggerRandomEnter : MonoBehaviour {
	
	public AudioClip[] audioClips;

	AudioSource audioSource;
	int selection;

	// Use this for initialization
	void Start () {
		selection = Random.Range(0, 4);
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = audioClips[selection];
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider other) {

		
	}
	
}
