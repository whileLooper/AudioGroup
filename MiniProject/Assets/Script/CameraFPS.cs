using UnityEngine;
using System.Collections;

public class CameraFPS : MonoBehaviour {

	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	public AudioClip[] clips;
	AudioSource source;
	
	float mHdg = 0F;
	float mPitch = 0F;
	float pitch = 1f;

	bool moving = false;
	
	void Start()
	{
		source = GetComponent<AudioSource> ();
	}
	
	void Update()
	{
		float deltaX = Input.GetAxis("Mouse X") * sensitivityX;
		float deltaY = Input.GetAxis("Mouse Y") * sensitivityY;
		
		if (Input.GetKey(KeyCode.D))
		{
			Strafe(1);
			moving = true;
			if (source.isPlaying) {
				source.Stop ();
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			Strafe (-1);
			moving = true;
			if (source.isPlaying) {
				source.Stop ();
			}
		}
		if (Input.GetKey (KeyCode.W)) {
			MoveForwards(1);
			moving = true;
			if (source.isPlaying) {
				source.Stop ();
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			MoveForwards (-1);
			moving = true;
			if (source.isPlaying) {
				source.Stop ();

			}
		}

		if (!moving) {
			source.clip = clips[1];
			if (!source.isPlaying) {
				source.volume = 0.8f;
				source.pitch = 1f;
				source.Play();

			}
		}
		
		if (Input.GetMouseButton(0))
		{
			ChangeHeading(deltaX);
			ChangePitch(-deltaY);
		}
		if (Input.GetKey(KeyCode.E)) {
			source.clip = clips[0];
			pitch += 0.01f;
			source.pitch = pitch;
			if (!source.isPlaying) {
				source.Play();
				source.volume = 1f;
			}
		}
		if (Input.GetKey (KeyCode.R)) {
			source.clip = clips[0];
			pitch -= 0.01f;
			source.pitch = pitch;
			if (source.pitch <= 0) source.pitch = 0;
			if (!source.isPlaying) {
				source.Play();
			}
		}
		moving = false;
	}
	
	void MoveForwards(float aVal)
	{
		Vector3 fwd = transform.forward;
		fwd.y = 0;
		fwd.Normalize();
		transform.position += aVal * fwd;
	}
	
	void Strafe(float aVal)
	{
		transform.position += aVal * transform.right;
	}
	
	void ChangeHeight(float aVal)
	{
		transform.position += aVal * Vector3.up;
	}
	
	void ChangeHeading(float aVal)
	{
		mHdg += aVal;
		WrapAngle(ref mHdg);
		transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
	}
	
	void ChangePitch(float aVal)
	{
		mPitch += aVal;
		WrapAngle(ref mPitch);
		transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
	}
	
	public static void WrapAngle(ref float angle)
	{
		if (angle <= -360F)
			angle += 360F;
		if (angle >= 360F)
			angle -= 360F;
	}
}
