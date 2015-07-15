﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float sensitivityX = 8F;
	public float sensitivityY = 8F;
	
	float mHdg = 0F;
	float mPitch = 0F;
	
	void Start()
	{
		// owt?
	}
	
	void Update()
	{
		
		float deltaX = Input.GetAxis("Mouse X") * sensitivityX;
		float deltaY = Input.GetAxis("Mouse Y") * sensitivityY;
		
		if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
		{
			Strafe(deltaX);
			ChangeHeight(deltaY);
		}
		if (Input.GetKey(KeyCode.A)) {
			print ("A pressed");
			Strafe(-1);
		}
		if (Input.GetKey (KeyCode.D)) {
			print ("D pressed");
			Strafe (1);
		}
		if (Input.GetKey (KeyCode.W))
		{
			MoveForwards(1);
		}
		if (Input.GetKey (KeyCode.S) )
		{
			MoveForwards(-1);
		}
		if (Input.GetMouseButton (1)) {
			ChangeHeading(deltaX);
			ChangePitch (-deltaY);
		}
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