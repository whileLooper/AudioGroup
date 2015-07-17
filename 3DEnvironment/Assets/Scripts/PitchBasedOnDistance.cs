using UnityEngine;
using System.Collections;

public class PitchBasedOnDistance : MonoBehaviour {

	float distance;
	public GameObject target;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(transform.position,target.transform.position);
		audioSource.pitch = (distance - 50) / 100f;
	}
}
