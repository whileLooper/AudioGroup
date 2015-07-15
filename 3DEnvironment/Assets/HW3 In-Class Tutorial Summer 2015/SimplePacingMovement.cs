using UnityEngine;
using System.Collections;

public class SimplePacingMovement : MonoBehaviour {

	public float movementRangeX = 5.0f;
	public float movementSpeed = 10.0f;
	Vector3 originalPosition;

	public float currentTimeInSeconds = 0;


	// Use this for initialization
	void Start () {
		originalPosition = transform.localPosition;
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTimeInSeconds += Time.deltaTime;
		float xMovement = Mathf.PingPong (currentTimeInSeconds, movementRangeX);
		Vector3 newPosition = originalPosition;
		newPosition.x += xMovement;
		transform.localPosition = newPosition;
	
	}
}
