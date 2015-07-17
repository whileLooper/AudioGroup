using UnityEngine;
using System.Collections;

public class SoundChangeBasedOnDistance : MonoBehaviour {

	public AudioClip[] audioClips;
	public GameObject target;

	float distance;

	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = audioClips [0];
		audioSource.Play ();
		audioSource.loop = true;
		audioSource.volume = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(transform.position,target.transform.position);

		if (distance < 30) {
			audioSource.clip = audioClips [1];
			audioSource.volume = 1f;
		} else {
			audioSource.clip = audioClips [0];
			audioSource.volume = 0.2f;
		}
		if (!audioSource.isPlaying) {
			audioSource.Play();
		}
	}
}
