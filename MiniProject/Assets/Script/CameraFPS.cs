using UnityEngine;
using System.Collections;

public class CameraFPS : MonoBehaviour {

	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	AudioSource source;
	
	float mHdg = 0F;
	float mPitch = 0F;
	
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
		}
		if (Input.GetKey (KeyCode.A)) {
			Strafe (-1);
		}
		if (Input.GetKey (KeyCode.W)) {
			MoveForwards(1);
		}
		if (Input.GetKey (KeyCode.S)) {
			MoveForwards (-1);
		}
		
		if (Input.GetMouseButton(0))
		{
			ChangeHeading(deltaX);
			ChangePitch(-deltaY);
		}
		if (Input.GetKey(KeyCode.E)) {
			source.pitch += 0.01f;
			if (!source.isPlaying) {
				source.Play();
			}
		}
		if (Input.GetKey (KeyCode.R)) {
			source.pitch -= 0.01f;
			if (source.pitch <= 0) source.pitch = 0;
			if (!source.isPlaying) {
				source.Play();
			}
		}
		print (source.pitch);
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
