using UnityEngine;
using System.Collections;

public class TriggerZoneExample : MonoBehaviour {

	public Color triggerExitColor = new Color (0, 1, 0, 0.5f); //green
	public Color triggerEnterColor = new Color (1, 0, 0, 0.5f); //red
	public GameObject planeIndicator;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = triggerExitColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
	void OnTriggerEnter(Collider other) {

		//ways to check to see if a specific object has entered the trigger:

		//Presence of a Component:
		//checking to see if the object we collided with has a CharacterController

		CharacterController controller = other.gameObject.GetComponent<CharacterController>();
		if (controller != null) //only change color when character controller found
		{
			GetComponent<Renderer>().material.color = triggerEnterColor;
			if (planeIndicator != null)
				planeIndicator.GetComponent<Renderer>().material.color = triggerEnterColor;

			Debug.Log (gameObject.name + ": entered trigger with name " + other.transform.name);
		}

		//Tags:
		//Checking to see if the object that entered the trigger has a specific trigger:
		if (other.gameObject.tag == "Player") 
			//you can also check for tags 
			//(change the tag for your first-person controller to "Player" to make this work)
		{

		}
	}
	
	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerStay.html
	void OnTriggerStay(Collider other) {
		
	}
	
	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerExit.html
	void OnTriggerExit(Collider other) {
		//note that we are not checking tags or components here

		GetComponent<Renderer>().material.color = triggerExitColor;
		if (planeIndicator != null)
			planeIndicator.GetComponent<Renderer>().material.color = triggerExitColor;
		Debug.Log (gameObject.name + ": exited trigger with name " + other.transform.name);
	}

}
